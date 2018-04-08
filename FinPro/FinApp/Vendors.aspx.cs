using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinPro.FinApp
{
    public partial class Vendors : System.Web.UI.Page
    {
        int maxRows = 0;
        int isOfficial = 0;
        int thisUser = 1;
        int moduleId = 1;
        int currentPage = 1;
        int pageSize = 10;
        int maxPageShow = 10;
        bool showLastPages = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Grid();
            }
        }

        protected void Load_Grid()
        {
            iBiz.FinPro.Generic.Vendors bVendors = new iBiz.FinPro.Generic.Vendors();
            lvGrid.DataSource = bVendors.Select();
            lvGrid.DataBind();
        }

        protected void Do_Pagination(object source, object e)
        {
            if (source == null && e == null)
            {
                DataTable dt = new DataTable();
                DataTable dtLastPages = new DataTable();
                dt.Columns.Add("pageNo");
                dt.Columns.Add("selectedCSS");

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
                        if (i == currentPage)
                        {
                            dt.Rows.Add(i.ToString(), "active");
                        }
                        else
                        {
                            dt.Rows.Add(i.ToString(), "");
                        }
                    }
                }

                if (currentPage == 1)
                {
                    sample_2_previous.Attributes.Add("class", "paginate_button previous disabled");
                }
                else
                {
                    sample_2_previous.Attributes.Add("class", "paginate_button previous");
                }


                if (currentPage == totalPageCount)
                {
                    sample_2_next.Attributes.Add("class", "paginate_button next disabled");
                }
                else
                {
                    sample_2_next.Attributes.Add("class", "paginate_button next");
                }

                //ltrPageSummary.Text = currentPage.ToString() + " of " + totalPageCount.ToString();


                rptStartPaging.DataSource = dt;
                rptStartPaging.DataBind();
                //lblDotted.Visible = false;

                if (showLastPages)
                {
                    //lblDotted.Visible = true;
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


                //rptStartPaging.DataSource = dt;
                //rptStartPaging.DataBind();
            }
            else
            {
                pageSize = Convert.ToInt32(ddlPaginationRows.SelectedValue);

                if (source is Repeater)
                {
                    RepeaterCommandEventArgs arg = (RepeaterCommandEventArgs)e;
                    currentPage = Convert.ToInt32(arg.CommandArgument);
                    hfCurrentPage.Value = currentPage.ToString();
                    Load_Grid();
                }
                else if (source is LinkButton)
                {
                    LinkButton buttonPressed = (LinkButton)source;
                    if (buttonPressed.UniqueID.ToString().Contains("lbtnNext"))
                    {
                        currentPage = Convert.ToInt32(hfCurrentPage.Value);
                        currentPage++;
                        hfCurrentPage.Value = currentPage.ToString();
                        Load_Grid();
                    }
                    else if (buttonPressed.UniqueID.ToString().Contains("lbtnPrevious"))
                    {
                        currentPage = Convert.ToInt32(hfCurrentPage.Value);
                        currentPage--;
                        hfCurrentPage.Value = currentPage.ToString();
                        Load_Grid();
                    }
                }
                else if (source is DropDownList)
                {
                    Load_Grid();
                }
            }

            ddlPaginationRows.SelectedValue = pageSize.ToString();
        }
    }
}