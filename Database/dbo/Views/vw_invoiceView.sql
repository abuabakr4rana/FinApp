CREATE VIEW [dbo].[vw_invoiceView]
AS
SELECT        dbo.fin_Departments.deptTitle, dbo.fin_InvoiceItems.invItemId, dbo.fin_InvoiceItems.invUid, dbo.fin_InvoiceItems.invItemAccId, dbo.fin_InvoiceItems.transId, dbo.fin_InvoiceItems.invItemDescription, 
                         dbo.fin_InvoiceItems.invItemCost, dbo.fin_InvoiceItems.invItemQty, dbo.fin_InvoiceItems.invItemTax1Id, dbo.fin_InvoiceItems.invItemTax1Rate, dbo.fin_InvoiceItems.invItemTax1Amount, 
                         dbo.fin_InvoiceItems.invItemTax2Id, dbo.fin_InvoiceItems.invItemTax2Rate, dbo.fin_InvoiceItems.invItemTax2Amount, dbo.fin_InvoiceItems.invItemCreatedOn, dbo.fin_InvoiceItems.invItemCreatedBy, 
                         dbo.fin_InvoiceItems.invItemCreationIP, dbo.fin_InvoiceItems.invItemStatus, dbo.fin_InvoiceItems.invItemDeptId, 
                         dbo.fin_InvoiceItems.invItemCost * dbo.fin_InvoiceItems.invItemQty + dbo.fin_InvoiceItems.invItemTax1Amount + dbo.fin_InvoiceItems.invItemTax2Amount AS TotalAmount, dbo.fin_Invoices.invUserGroupId, 
                         dbo.fin_Invoices.invUserGroupInvId, dbo.fin_Invoices.invCreatedBy, dbo.fin_Invoices.invCreatedOn, dbo.fin_Invoices.invCreatedIP, dbo.fin_Invoices.invPoUid, dbo.fin_Invoices.invToEntityId, 
                         dbo.fin_Invoices.invDate, dbo.fin_Invoices.invPaymentTerms, dbo.fin_Invoices.invNotes, dbo.fin_Invoices.invDiscountId, dbo.fin_Invoices.invDiscountAmount, dbo.fin_Invoices.invStatus, 
                         dbo.fin_Invoices.invDescription, dbo.fin_Invoices.invRefId, dbo.fin_Invoices.invDueDate, dbo.fin_Accounts.accountTitle
FROM            dbo.fin_InvoiceItems INNER JOIN
                         dbo.fin_Invoices ON dbo.fin_InvoiceItems.invUid = dbo.fin_Invoices.invUid INNER JOIN
                         dbo.fin_Departments ON dbo.fin_InvoiceItems.invItemDeptId = dbo.fin_Departments.deptId INNER JOIN
                         dbo.fin_Accounts ON dbo.fin_InvoiceItems.invItemAccId = dbo.fin_Accounts.accountID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[57] 4[5] 2[12] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "fin_InvoiceItems"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 235
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_Invoices"
            Begin Extent = 
               Top = 8
               Left = 387
               Bottom = 138
               Right = 583
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_Departments"
            Begin Extent = 
               Top = 144
               Left = 305
               Bottom = 274
               Right = 478
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_Accounts"
            Begin Extent = 
               Top = 143
               Left = 609
               Bottom = 273
               Right = 852
            End
            DisplayFlags = 280
            TopColumn = 6
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 38
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 150', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_invoiceView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'0
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_invoiceView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_invoiceView';

