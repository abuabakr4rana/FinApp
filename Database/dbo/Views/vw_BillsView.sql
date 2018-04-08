CREATE VIEW [dbo].[vw_BillsView]
AS
SELECT        dbo.fin_Bills.billUserGroupId, dbo.fin_Bills.billUserGroupbillId, dbo.fin_Bills.billCreatedBy, dbo.fin_Bills.billCreatedOn, dbo.fin_Bills.billCreatedIP, dbo.fin_Bills.billPoUid, dbo.fin_Bills.billToEntityId, 
                         dbo.fin_Bills.billDate, dbo.fin_Bills.billPaymentTerms, dbo.fin_Bills.billNotes, dbo.fin_Bills.billDiscountId, dbo.fin_Bills.billDiscountAmount, dbo.fin_Bills.billStatus, dbo.fin_Bills.billDescription, 
                         dbo.fin_Bills.billRefId, dbo.fin_Bills.billDueDate, dbo.fin_BillItems.billItemId, dbo.fin_BillItems.billUid, dbo.fin_BillItems.billItemAccId, dbo.fin_BillItems.transId, dbo.fin_BillItems.billItemDescription, 
                         dbo.fin_BillItems.billItemCost, dbo.fin_BillItems.billItemQty, dbo.fin_BillItems.billItemTax1Id, dbo.fin_BillItems.billItemTax1Rate, dbo.fin_BillItems.billItemTax1Amount, dbo.fin_BillItems.billItemTax2Id, 
                         dbo.fin_BillItems.billItemTax2Rate, dbo.fin_BillItems.billItemTax2Amount, dbo.fin_BillItems.billItemCreatedOn, dbo.fin_BillItems.billItemCreatedBy, dbo.fin_BillItems.billItemCreationIP, 
                         dbo.fin_BillItems.billItemStatus, dbo.fin_BillItems.billItemDeptId, dbo.fin_Departments.deptTitle, 
                         dbo.fin_BillItems.billItemCost * dbo.fin_BillItems.billItemQty + dbo.fin_BillItems.billItemTax1Amount + dbo.fin_BillItems.billItemTax2Amount AS TotalAmount, dbo.fin_Accounts.accountTitle
FROM            dbo.fin_BillItems INNER JOIN
                         dbo.fin_Bills ON dbo.fin_BillItems.billUid = dbo.fin_Bills.billUid INNER JOIN
                         dbo.fin_Departments ON dbo.fin_BillItems.billItemDeptId = dbo.fin_Departments.deptId INNER JOIN
                         dbo.fin_Accounts ON dbo.fin_BillItems.billItemAccId = dbo.fin_Accounts.accountID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[42] 4[13] 2[19] 3) )"
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
         Begin Table = "fin_BillItems"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 235
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_Bills"
            Begin Extent = 
               Top = 2
               Left = 448
               Bottom = 132
               Right = 644
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_Departments"
            Begin Extent = 
               Top = 149
               Left = 274
               Bottom = 279
               Right = 447
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_Accounts"
            Begin Extent = 
               Top = 136
               Left = 574
               Bottom = 266
               Right = 817
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 18
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
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output =', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_BillsView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'720
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
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_BillsView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_BillsView';

