CREATE VIEW dbo.vw_Transactions
AS
SELECT        dbo.fin_Transactions.transID, dbo.fin_Transactions.transSystemIndex, dbo.fin_Transactions.transParticipantID, dbo.fin_Transactions.transRefID, dbo.fin_Transactions.transAttachedFiles, 
                         dbo.fin_Transactions.transInvoiceID, dbo.fin_Transactions.transDrAccount, dbo.fin_Transactions.transCrAccount, dbo.fin_Transactions.transNarration, dbo.fin_Transactions.transAmount, 
                         dbo.fin_Transactions.transCreatedOn, dbo.fin_Transactions.transCreatedBy, dbo.fin_Transactions.transUpdatedOn, dbo.fin_Transactions.transUpdatedBy, dbo.fin_Transactions.transStatus, 
                         dbo.fin_Transactions.transSystemRestrict, dbo.fin_Transactions.transGroupID, dbo.fin_Transactions.transIsCompound, dbo.fin_Transactions.transType, dbo.fin_TransGroups.transGroupTitle, 
                         dbo.fin_TransGroups.transGroupCreatedOn, dbo.fin_TransGroups.transGroupCreatedBy, dbo.fin_TransGroups.transGroupTotalAmount, dbo.fin_TransGroups.transTransCount, 
                         dbo.fin_TransGroups.transLinkedToGroup, dbo.fin_TransGroups.transGroupReviewedOn, dbo.fin_TransGroups.transGroupReviewedBy, dbo.fin_TransGroups.transGroupApprovedOn, 
                         dbo.fin_TransGroups.transGroupApprovedBy, dbo.fin_TransGroups.transGroupStatus, dbo.fin_TransGroups.transGroupForeNumber, dbo.fin_TransGroups.transGroupPrefixString, 
                         dbo.fin_TransGroups.transGroupPrefixNo, dbo.fin_Accounts.accountTitle, fin_Accounts_1.accountTitle AS crAccountTitle, dbo.fin_Transactions.deptId, dbo.fin_Departments.deptCode, 
                         dbo.fin_TransGroups.transGroupRefId, dbo.fin_gen_TransGroupStatus.transGroupStatusTitle
FROM            dbo.fin_Transactions INNER JOIN
                         dbo.fin_TransGroups ON dbo.fin_Transactions.transGroupID = dbo.fin_TransGroups.transGroupID INNER JOIN
                         dbo.fin_Departments ON dbo.fin_Transactions.deptId = dbo.fin_Departments.deptId INNER JOIN
                         dbo.fin_gen_TransGroupStatus ON dbo.fin_TransGroups.transGroupStatus = dbo.fin_gen_TransGroupStatus.transGroupStatus LEFT OUTER JOIN
                         dbo.fin_Accounts ON dbo.fin_Transactions.transDrAccount = dbo.fin_Accounts.accountID LEFT OUTER JOIN
                         dbo.fin_Accounts AS fin_Accounts_1 ON dbo.fin_Transactions.transCrAccount = fin_Accounts_1.accountID
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
         Begin Table = "fin_Transactions"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 323
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "fin_TransGroups"
            Begin Extent = 
               Top = 6
               Left = 268
               Bottom = 206
               Right = 487
            End
            DisplayFlags = 280
            TopColumn = 14
         End
         Begin Table = "fin_Departments"
            Begin Extent = 
               Top = 6
               Left = 1087
               Bottom = 196
               Right = 1260
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_Accounts"
            Begin Extent = 
               Top = 6
               Left = 525
               Bottom = 260
               Right = 768
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_Accounts_1"
            Begin Extent = 
               Top = 6
               Left = 806
               Bottom = 293
               Right = 1049
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "fin_gen_TransGroupStatus"
            Begin Extent = 
               Top = 202
               Left = 386
               Bottom = 315
               Right = 595
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
      Begin ColumnWidths = 36
         Width = 28', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_Transactions';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'4
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
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_Transactions';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_Transactions';

