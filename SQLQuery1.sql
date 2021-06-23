ALTER TABLE [dbo].[TblSaleBills]

ALTER COLUMN [Earn] nvarchar(50);
---------------------------

ALTER TABLE [dbo].[TblBackIn]

ALTER COLUMN [TotalPaybake] nvarchar(50);
---------------------------

ALTER TABLE [dbo].[TblBackInBill]

ALTER COLUMN [InPrice] nvarchar(50);
---------------------------


ALTER TABLE [dbo].[TblBackInBill]

ALTER COLUMN [InTotal] nvarchar(50);
---------------------------


ALTER TABLE [dbo].[TblBackOut]

ALTER COLUMN [TotalMony] nvarchar(50);
---------------------------

ALTER TABLE [dbo].[TblBackOutBills]

ALTER COLUMN [OutPrice]nvarchar(50);
---------------------------

ALTER TABLE [dbo].[TblBackOutBills]

ALTER COLUMN [OutTotal]nvarchar(50);
---------------------------


ALTER TABLE [dbo].[TblBills]

ALTER COLUMN [TotalPaid] nvarchar(50);
---------------------------


ALTER TABLE [dbo].[TblCorrupted]

ALTER COLUMN [CorruptedLost] nvarchar(50);
---------------------------


ALTER TABLE [dbo].[TblCorruptedBills]

ALTER COLUMN [CoMoney] nvarchar(50);
---------------------------


ALTER TABLE [dbo].[TblExpenses]

ALTER COLUMN [Money] nvarchar(50);
---------------------------



ALTER TABLE [dbo].[TblIncome]

ALTER COLUMN [IncomeValue] nvarchar(50);
---------------------------


ALTER TABLE [dbo].[TblProductsMovements]

ALTER COLUMN [MoveValue] nvarchar(50);

---------------------------

ALTER TABLE [dbo].[TblPurchases]

ALTER COLUMN [BPrice] nvarchar(50);

---------------------------
ALTER TABLE  [dbo].[TblPurchases]
ALTER COLUMN [BTatol] nvarchar(50);
---------------------------

ALTER TABLE  [dbo].[TblStorages]
ALTER COLUMN [TotalMoney] nvarchar(350);



