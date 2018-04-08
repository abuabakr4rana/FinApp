using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FinPro.Controls
{
	public partial class wucDataPager : System.Web.UI.UserControl
	{
        public int maxRows { get; set; }
        public int pageSize { get; set; }
        public int currentPage { get; set; }
        public int maxPageShow { get; set; }
        public bool showLastPages { get; set; }

		public delegate void EventHandler(Object obj, EventArgs e);
        public event EventHandler PageChange;
        public event EventHandler NextPageClicked;
        public event EventHandler PreviousPageClicked;
        

        public wucDataPager()
        {
            //currentPage = currentPage == 0 ? 1 : currentPage;
            //currentPage = Convert.ToInt32(hfCurrentPage.Value);
            //pageSize = pageSize == 0 ? 1 : pageSize;
 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            currentPage = Convert.ToInt32(hfCurrentPage.Value);
            pageSize = pageSize == 0 ? 1 : pageSize;
            hfCurrentPage.Value = currentPage.ToString();
            Load_Pages();
        }

        protected void Load_Pages()
        {
            pnlPager.Visible = false;

            DataTable dt = new DataTable();
            DataTable dtLastPages = new DataTable();
            dt.Columns.Add("pageNo");
            dtLastPages.Columns.Add("pageNo");

            int totalPageCount = maxRows / pageSize;
            double remainder = Math.IEEERemainder(maxRows, pageSize);
            double halfOfMaxPageShow = maxPageShow / 2;

            if (remainder > 0)
            {
                totalPageCount++;
            }


            int startPage = currentPage - Convert.ToInt32(halfOfMaxPageShow);
            int endPage = currentPage + Convert.ToInt32(halfOfMaxPageShow);


            for (int i = startPage; i <= endPage; i++)
            {
                if (i > 0 && i <= totalPageCount)
                {
                    pnlPager.Visible = true;
                    dt.Rows.Add(i.ToString());
                }
            }


            ltrPageSummary.Text = currentPage.ToString() + " of " + totalPageCount.ToString();


            rptPages.DataSource = dt;
            rptPages.DataBind();
            lblDotted.Visible = false;
            if (showLastPages)
            {
                lblDotted.Visible = true;
                rptLastPages.DataSource = dtLastPages;
                rptLastPages.DataBind();
            }


			if (currentPage == 1)
			{
				lbtnPrevious.Enabled = false;	
			}
			else
			{
				lbtnPrevious.Enabled = true;
				lbtnNext.CommandArgument = Convert.ToString(currentPage - 1);
			}

			if (currentPage == totalPageCount)
			{
				lbtnNext.Enabled = false;
			}
			else
			{
				lbtnNext.Enabled = true;
				lbtnNext.CommandArgument = Convert.ToString(currentPage + 1);
			}
        }
        protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            currentPage = Convert.ToInt32(e.CommandArgument);
            hfCurrentPage.Value = currentPage.ToString();

            if (this.PageChange != null)
                this.PageChange(this, e);
            Load_Pages();
        }
        protected void lbtnPrevious_Click(object sender, EventArgs e)
        {
            if (this.PreviousPageClicked != null)
                this.PreviousPageClicked(this, e);
            //    currentPage = Convert.ToInt32(hfCurrentPage.Value);

			if (currentPage > 0)
			{
				currentPage--;
				hfCurrentPage.Value = currentPage.ToString();
				Load_Pages();
			}
        }
        protected void lbtnNext_Click(object sender, EventArgs e)
        {
            if (this.NextPageClicked != null)
                this.NextPageClicked(this, e);

		
            currentPage++;
            hfCurrentPage.Value = currentPage.ToString();
            Load_Pages();
        }

        protected string isSelectedCss(string pageNo)
        {
            string rt = "";

            if (pageNo == hfCurrentPage.Value)
            {
                rt = "pager_selected";
            }

            return rt;
        }
	}
}