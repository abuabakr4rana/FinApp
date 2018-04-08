CREATE VIEW dbo.vw_Invoices
AS
SELECT        dbo.fin_Invoices.invUid, dbo.fin_Invoices.invUserGroupId, dbo.fin_Invoices.invUserGroupInvId, dbo.fin_Invoices.invCreatedBy, dbo.fin_Invoices.invCreatedOn, dbo.fin_Invoices.invCreatedIP, 
                         dbo.fin_Invoices.invPoUid, dbo.fin_Invoices.invToEntityId, dbo.fin_Invoices.invDate, dbo.fin_Invoices.invPaymentTerms, dbo.fin_Invoices.invNotes, dbo.fin_Invoices.invDiscountId, 
                         dbo.fin_Invoices.invDiscountAmount, dbo.fin_Invoices.invStatus, dbo.fin_Invoices.invDescription, dbo.fin_Invoices.invRefId, dbo.fin_Invoices.invDueDate, dbo.fin_Accounts.accountTitle, 
                         dbo.fin_Generic_InvoiceStatus.invStatusTitle, dbo.userProfile.userFirstName, dbo.userProfile.userLastName
FROM            dbo.fin_Invoices INNER JOIN
                         dbo.fin_Accounts ON dbo.fin_Invoices.invToEntityId = dbo.fin_Accounts.accountID INNER JOIN
                         dbo.fin_Generic_InvoiceStatus ON dbo.fin_Invoices.invStatus = dbo.fin_Generic_InvoiceStatus.invStatusId INNER JOIN
                         dbo.userProfile ON dbo.fin_Invoices.invCreatedBy = dbo.userProfile.userID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "fin_Invoices"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 202
               Right = 234
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "fin_Accounts"
            Begin Extent = 
               Top = 189
               Left = 357
               Bottom = 385
               Right = 600
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_Generic_InvoiceStatus"
            Begin Extent = 
               Top = 172
               Left = 283
               Bottom = 302
               Right = 580
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "userProfile"
            Begin Extent = 
               Top = 6
               Left = 761
               Bottom = 202
               Right = 941
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
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_Invoices';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_Invoices';

