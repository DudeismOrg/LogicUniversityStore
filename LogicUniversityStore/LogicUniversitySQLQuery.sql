delete from dbo.PurchaseOrderItem;
delete from dbo.PurchaseOrder;
delete from dbo.RequisitionItem;
delete from dbo.Requisition;
delete from dbo.SupplierItem;
delete from dbo.Item;
delete from dbo.Supplier;
delete from dbo.LUUser;
delete from dbo.Department;
delete from dbo.CollectionPoint;
delete from dbo.category;
delete from dbo.role;



DBCC CHECKIDENT ('[dbo].[Role]', RESEED, 1);
DBCC CHECKIDENT ('[dbo].[Category]', RESEED, 1);
DBCC CHECKIDENT ('[dbo].[CollectionPoint]', RESEED, 1);
DBCC CHECKIDENT ('[dbo].[Supplier]', RESEED, 1);
DBCC CHECKIDENT ('[dbo].[SupplierItem]', RESEED, 1);
DBCC CHECKIDENT ('[dbo].[Department]', RESEED,1);
DBCC CHECKIDENT ('[dbo].[LUUser]', RESEED,1);
DBCC CHECKIDENT ('[dbo].[Item]', RESEED, 1);
DBCC CHECKIDENT ('[dbo].[StockCard]', RESEED, 1);
DBCC CHECKIDENT ('[dbo].[PurchaseOrder]', RESEED, 1);
DBCC CHECKIDENT ('[dbo].[PurchaseOrderItem]', RESEED, 1);
DBCC CHECKIDENT ('[dbo].[Requisition]', RESEED, 1);
DBCC CHECKIDENT ('[dbo].[RequisitionItem]', RESEED, 1);



insert into dbo.Role (rolecode, rolename, deptype) values
('HOD', 'Department Head', 'Faculty'),
('REP', 'Department Representative', 'Faculty'),
('CLERK', 'Store Clerk', 'Store'),
('SUPERVISOR', 'Store Supervisor', 'Store'),
('MANAGER', 'Store Manager', 'Store'),
('EMP', 'Department Employee', 'Faculty');



INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Clip', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Envelope', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Eraser', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Excercise', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'File', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Puncher', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Pad', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Paper', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Pen', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Ruler', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Scissors', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Tape', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Sharpener', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Shorthand', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Stapler', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Tacks', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Tparency', NULL, NULL)
INSERT [dbo].[Category] ([CategoryCode], [CategoryName], [Remarks]) VALUES (N'Tray', NULL, NULL)


insert into dbo.CollectionPoint(CollectionPoint)
values('Stationery Store'),
('Management School'),
('Medical School'),
('Engineering School'),
('Science School'),
('Universty Hospital');

INSERT [dbo].[Supplier] ([SupplierCode], [SupplierName], [SupplierContact], [SupplierPhone], [SupplierFax], [SupplierAddress], [GSTRegistrationNumber], [MinDeliveryDay]) VALUES (N'ALPA      ', N'ALPHA Office Supplies         ', N'Ms Irene Tan                  ', N'64619928            ', N'64612238            ', N'Blk 1128, Ang Mo Kio Industrial Park #02-1108 Ang Mo Kio Street 62 Singapore 622262                 ', N'MR-8500440-2        ', 3)
INSERT [dbo].[Supplier] ([SupplierCode], [SupplierName], [SupplierContact], [SupplierPhone], [SupplierFax], [SupplierAddress], [GSTRegistrationNumber], [MinDeliveryDay]) VALUES (N'CHEP      ', N'Cheap Stationer               ', N'Mr Soh Kway Koh               ', N'63543234            ', N'64742434            ', N'Blk 34, Clementi Road #07-02 Ban Ban Soh Building Singapore 110525                                  ', N'                    ', 4)
INSERT [dbo].[Supplier] ([SupplierCode], [SupplierName], [SupplierContact], [SupplierPhone], [SupplierFax], [SupplierAddress], [GSTRegistrationNumber], [MinDeliveryDay]) VALUES (N'BANE      ', N'BANES Shop                    ', N'Mr Loh Ah Pek                 ', N'64781234            ', N'64792434            ', N'Blk 124, Alexandra Road #03-04 Banes Building Singapore 550315                                      ', N'MR-8200420-2        ', 5)
INSERT [dbo].[Supplier] ([SupplierCode], [SupplierName], [SupplierContact], [SupplierPhone], [SupplierFax], [SupplierAddress], [GSTRegistrationNumber], [MinDeliveryDay]) VALUES (N'OMEG      ', N'OMEGA Stationery Supplier     ', N'Mr Ronnie Ho                  ', N'67671233            ', N'67671234            ', N'Blk 11, Hillview  Avenue #03-04 Singapore 679036                                                    ', N'MR-8555330-1        ', 5)
INSERT [dbo].[Supplier] ([SupplierCode], [SupplierName], [SupplierContact], [SupplierPhone], [SupplierFax], [SupplierAddress], [GSTRegistrationNumber], [MinDeliveryDay]) VALUES (N'ALPA', N'ALPHA Office Supplies', N'Ms Irene Tan', N'64619928', N'64612238', N'Blk 1128, Ang Mo Kio Industrial Park #02-1108 Ang Mo Kio Street 62 Singapore 622262', N'MR-8500440-2', 5)
INSERT [dbo].[Supplier] ([SupplierCode], [SupplierName], [SupplierContact], [SupplierPhone], [SupplierFax], [SupplierAddress], [GSTRegistrationNumber], [MinDeliveryDay]) VALUES (N'CHEP', N'Cheap Stationer', N'Mr Soh Kway Koh', N'63543234', N'64742434', N'Blk 34, Clementi Road #07-02 Ban Ban Soh Building Singapore 110525', N'', 5)
INSERT [dbo].[Supplier] ([SupplierCode], [SupplierName], [SupplierContact], [SupplierPhone], [SupplierFax], [SupplierAddress], [GSTRegistrationNumber], [MinDeliveryDay]) VALUES (N'BANE', N'BANES Shop', N'Mr Loh Ah Pek', N'64781234', N'64792434', N'Blk 124, Alexandra Road #03-04 Banes Building Singapore 550315', N'MR-8200420-2', 5)
INSERT [dbo].[Supplier] ([SupplierCode], [SupplierName], [SupplierContact], [SupplierPhone], [SupplierFax], [SupplierAddress], [GSTRegistrationNumber], [MinDeliveryDay]) VALUES (N'OMEG', N'OMEGA Stationery Supplier', N'Mr Ronnie Ho', N'67671233', N'67671234', N'Blk 11, Hillview  Avenue #03-04 Singapore 679036', N'MR-8555330-1', 5)


INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'C001', N'Clips Double 1', N'Clips Double 1', N'Dozen', 5.25, NULL, 1, 50, 30)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'E001', N'Envelope Brown(3*6)', N'Envelope Brown(3*6)', N'Each', 0.4, NULL, 2, 600, 400)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'E020', N'Eraser(hard)', N'Eraser(hard)', N'Each', 1, NULL, 3, 50, 20)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'E030', N'Excercise Book(100 pg)', N'Excercise Book(100 pg)', N'Each', 5, NULL, 4, 100, 50)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'F020', N'File Seperator', N'File Seperator', N'Set', 3.75, NULL, 5, 100, 50)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'F021', N'File-Blue Plain', N'File-Blue Plain', N'Each', 5.25, NULL, 5, 200, 100)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'F022', N'File-Blue with Logo', N'File-Blue with Logo', N'Each', 7.75, NULL, 5, 200, 100)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'F031', N'Folder Plastic Blue', N'Folder Plastic Blue', N'Each', 5.75, NULL, 5, 200, 150)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'F035', N'Folder Plastic Yellow', N'Folder Plastic Yellow', N'Each', 5.75, NULL, 5, 200, 150)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'P010', N'Pad Postit Memo 1x2', N'Pad Postit Memo 1x2', N'Packet', 3, NULL, 7, 100, 60)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'P011', N'Pad Postit Memo 1/2x1', N'Pad Postit Memo 1/2x1', N'Packet', 2.25, NULL, 7, 100, 60)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'P014', N'Pad Postit Memo 2x4', N'Pad Postit Memo 2x4', N'Packet', 5.25, NULL, 7, 100, 60)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'P013', N'Pad Postit Memo 2x3', N'Pad Postit Memo 2x3', N'Packet', 4.25, NULL, 7, 100, 60)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'H031', N'Hole Puncher 2 holes', N'Hole Puncher 2 holes', N'Each', 5, NULL, 6, 50, 20)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'P020', N'Paper Photostat A3', N'Paper Photostat A3', N'Box', 15, NULL, 8, 500, 500)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'P030', N'Pen Ballpoint Black', N'Pen Ballpoint Black', N'Dozen', 7.5, NULL, 9, 100, 50)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'P043', N'Pencil 2B with Eraser End', N'Pencil 2B with Eraser End', N'Dozen', 5, NULL, 9, 100, 50)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'R002', N'Ruler 12', N'Ruler 12', N'Dozen', 3, NULL, 10, 50, 20)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'S100', N'Scissors', N'Scissors', N'Each', 2, NULL, 11, 50, 20)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'S040', N'Scotch Tape', N'Scotch Tape', N'Each', 1.5, NULL, 12, 50, 20)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'S101', N'Sharpener', N'Sharpener', N'Each', 0.75, NULL, 13, 50, 20)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'S010', N'Shorthand Book (100pg)', N'Shorthand Book (100pg)', N'Each', 1.25, NULL, 14, 100, 80)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'S020', N'Stapler No. 28', N'Stapler No. 28', N'Each', 2.25, NULL, 15, 50, 20)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'T001', N'Thumb Tacks Large', N'Thumb Tacks Large', N'Box', 3.45, NULL, 16, 10, 10)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'T020', N'Transparency Blue', N'Transparency Blue', N'Box', 13.25, NULL, 17, 100, 200)
INSERT [dbo].[Item] ([ItemCode], [ItemName], [ItemDesc], [UOM], [BasePrice], [Status], [CategoryID], [ReorderLevel], [ReorderQuantity]) VALUES (N'T100', N'Trays In/Out', N'Trays In/Out', N'Set', 6.75, NULL, 18, 20, 10)



INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (1, 1, 5.25, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (2, 1, 0.4, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (3, 1, 1, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (4, 1, 5, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (5, 1, 3.75, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (6, 1, 5.25, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (7, 1, 7.75, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (8, 1, 5.75, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (9, 1, 5.75, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (10, 1, 3, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (11, 1, 2.25, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (12, 1, 5.25, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (13, 1, 4.25, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (1, 2, 5.5, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (2, 2, 0.6, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (3, 2, 1.15, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (4, 2, 5.25, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (5, 2, 4.15, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (6, 2, 5.3, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (7, 2, 7.8, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (8, 2, 5.8, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (9, 2, 6, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (10, 2, 3.15, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (11, 2, 2.4, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (12, 2, 5.35, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (13, 2, 4.35, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (1, 3, 5.75, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (2, 3, 0.8, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (3, 3, 1.25, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (4, 3, 5.3, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (5, 3, 4, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (6, 3, 5.75, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (7, 3, 7.9, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (8, 3, 6.15, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (9, 3, 5.9, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (10, 3, 3.3, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (11, 3, 2.3, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (12, 3, 5.55, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (13, 3, 4.75, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (14, 1, 5.25, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (14, 2, 5.15, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (14, 3, 5.1, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (15, 1, 15, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (15, 2, 15.15, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (15, 3, 15.2, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (16, 1, 7.5, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (16, 2, 7.75, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (16, 3, 7.75, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (17, 1, 5, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (17, 2, 5.25, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (17, 3, 5.3, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (18, 1, 3, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (18, 2, 3.15, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (18, 3, 3, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (19, 1, 2, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (19, 2, 2.25, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (19, 3, 2.25, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (20, 1, 1.5, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (20, 2, 1.5, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (20, 3, 1.5, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (21, 1, 0.75, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (21, 2, 1, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (21, 3, 0.9, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (22, 1, 1.25, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (22, 2, 1.3, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (22, 3, 1.5, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (23, 1, 2.25, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (23, 2, 2.5, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (23, 3, 2.75, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (24, 1, 3.45, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (24, 2, 3.5, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (24, 3, 3.55, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (25, 1, 13.25, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (25, 2, 13.5, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (25, 3, 13.55, 1, 3)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (26, 1, 6.75, 1, 1)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (26, 2, 6.8, 1, 2)
INSERT [dbo].[SupplierItem] ([ItemID], [SupplierID], [Price], [ActiveSupplier], [SupplierPriority]) VALUES (26, 3, 6.9, 1, 3)



insert into dbo.Department(DepartmentCode,DepartmentName,ContactName,DepartmentPhone,DepartmentFax,HodID,CollectionPointID,RepresentativeID)
values('ENGL','English Dept','Mrs Pamela Kow','8742234','8921456',3,1,1),
('CPSC','Computer Science','Mr Wee Kian Fatt','8901235','8921457',15,2,14),
('COMM','Commerce Dept','Mr Mohd.Azman','8741284','8921256',6,3,5),
('REGR','Registrar Dept','Ms Helen Ho','8901266','8921465',8,4,7),
('ZOOL','Zoology Dept','Mr.Peter Tan Ah Meng','8901266','8921465',10,5,9),
('STORE','STORE Dept','Logic  UniStore','8901266','8921465',10,5,9),
('ISS','ISS','Dr. Esther Tan','8901235','8921457',17,3,16);

insert into dbo.LUUser (username, firstname, lastname, password, roleid, email, address, departmentid)
values
('empeng', 'English', 'Employee', 'empeng', 6, 'cpscreq@lu.edu.sg', 'Blk 123 Wonderful Street', 1),
('clerk', 'Store', 'Department', 'clerk', 3, 'englreq@lu.edu.sg', 'Blk 123 Wonderful Street', 6),
('hodeng', 'English', 'HOD', 'hodeng', 1, 'englhod@lu.edu.sg', 'Blk 123 Wonderful Street', 1),
('hodcpsc', 'Computer Science', 'Department', 'hodcpsc', 1, 'cpscreq@lu.edu.sg', 'Blk 123 Wonderful Street', 2),
('repcomm','Commerce','Department','repcomm',2,'cpscreq@lu.edu.sg','Blk 123 Wonderful Street',3), 
('hodcomm', 'Commerce', 'Department', 'hodcomm', 1, 'cpschod@lu.edu.sg', 'Blk 123 Wonderful Street', 3),
('repregr','Registrar','Department','repregr',2,'cpscreq@lu.edu.sg','Blk 123 Wonderful Street',4),
('hodregr', 'Registrar', 'Department', 'hodregr', 1, 'commreq@lu.edu.sg', 'Blk 123 Wonderful Street', 4),
('repzool', 'Zoology', 'Department', 'repzool', 2, 'zoolreq@lu.edu.sg', 'Blk 123 Wonderful Street', 5),
('hodzool', 'Zoology', 'Department', 'hodzool', 1, 'zoolhod@lu.edu.sg', 'Blk 123 Wonderful Street', 5),
('suprstore', 'Store', 'Store', 'suprstore', 4, 'zoolreq@lu.edu.sg', 'Blk 123 Wonderful Street', 6),
('mgrstore', 'Store', 'Store', 'mgrstore', 5, 'zoolhod@lu.edu.sg', 'Blk 123 Wonderful Street', 6),
('clrkstore', 'Store', 'Store', 'clrkstore', 3, 'zoolhod@lu.edu.sg', 'Blk 123 Wonderful Street', 6),
('empcom', 'Computer Science', 'Employee', 'empcom', 6, 'cpscreq@lu.edu.sg', 'Blk 123 Wonderful Street', 2),
('hodcom', 'Computer Science', 'HOD', 'hodcom', 1, 'englhod@lu.edu.sg', 'Blk 123 Wonderful Street', 2),
('empiss', 'ISS', 'Employee', 'empiss', 6, 'cpscreq@lu.edu.sg', 'Blk 123 Wonderful Street', 7),
('hodiss', 'ISS', 'HOD', 'hodiss', 1, 'englhod@lu.edu.sg', 'Blk 123 Wonderful Street', 7),
('repeng', 'English', 'Representative', 'repeng', 2, 'cpscreq@lu.edu.sg', 'Blk 123 Wonderful Street', 1),
('repcom', 'Computer Science', 'Representative', 'repcom', 2, 'cpscreq@lu.edu.sg', 'Blk 123 Wonderful Street', 2),
('repiss', 'ISS', 'Representative', 'repiss', 2, 'cpscreq@lu.edu.sg', 'Blk 123 Wonderful Street', 7);





--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)
--INSERT [dbo].[POBatch] ([POBatchDate], [Printed], [GeneratedBy]) VALUES (CAST(N'2017-02-01' AS Date), 0, NULL)




--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'Remark', CAST(N'2017-02-04' AS Date), 3)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 4)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 5)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 6)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 7)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 8)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'2', CAST(N'2017-02-01' AS Date), N'', N'', 2, NULL, N'', N'', CAST(N'2017-02-05' AS Date), 9)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'2', CAST(N'2017-02-01' AS Date), N'', N'', 2, NULL, N'', N'', CAST(N'2017-02-05' AS Date), 10)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'2', CAST(N'2017-02-01' AS Date), N'', N'', 2, NULL, N'', N'', CAST(N'2017-02-05' AS Date), 10)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'2', CAST(N'2017-02-01' AS Date), N'', N'', 2, NULL, N'', N'', CAST(N'2017-02-05' AS Date), 11)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'2', CAST(N'2017-02-01' AS Date), N'', N'', 2, NULL, N'', N'', CAST(N'2017-02-05' AS Date), 12)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 13)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 14)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'2', CAST(N'2017-02-01' AS Date), N'', N'', 2, NULL, N'', N'', CAST(N'2017-02-05' AS Date), 15)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 16)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 17)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 18)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 18)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 19)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 19)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'3', CAST(N'2017-02-01' AS Date), N'', N'', 3, NULL, N'', N'', CAST(N'2017-02-06' AS Date), 20)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'3', CAST(N'2017-02-01' AS Date), N'', N'', 3, NULL, N'', N'', CAST(N'2017-02-06' AS Date), 20)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'3', CAST(N'2017-02-01' AS Date), N'', N'', 3, NULL, N'', N'', CAST(N'2017-02-06' AS Date), 21)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'3', CAST(N'2017-02-01' AS Date), N'', N'', 3, NULL, N'', N'', CAST(N'2017-02-06' AS Date), 22)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'1', CAST(N'2017-02-01' AS Date), N'', N'', 1, NULL, N'', N'', CAST(N'2017-02-04' AS Date), 23)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'2', CAST(N'2017-02-01' AS Date), N'', N'', 2, NULL, N'', N'', CAST(N'2017-02-05' AS Date), 1)
--INSERT [dbo].[PurchaseOrder] ([PuchaseOrderNo], [OrderDate], [DeliveryAddress], [POStatus], [SupplierID], [OrderEmpID], [DONumber], [PORemark], [ExpectedDeliveryDate], [POBatchID]) VALUES (N'3', CAST(N'2017-02-01' AS Date), N'', N'', 3, NULL, N'', N'', CAST(N'2017-02-06' AS Date), 2)




--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (1, 1, 30, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (25, 1, 200, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (2, 2, 400, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (15, 2, 500, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (25, 3, 200, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (26, 3, 10, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (4, 4, 50, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (16, 4, 50, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (15, 4, 500, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (26, 5, 10, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (19, 5, 20, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (1, 5, 30, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (6, 6, 100, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (7, 6, 100, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (1, 7, 30, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (5, 7, 200, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (11, 8, 60, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (11, 9, 60, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (11, 10, 60, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (13, 10, 60, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (11, 11, 60, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (11, 12, 60, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (11, 13, 60, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (4, 13, 50, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (20, 14, 20, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (18, 14, 20, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (22, 14, 80, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (3, 15, 20, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (14, 15, 20, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (17, 15, 50, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (10, 16, 60, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (12, 16, 60, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (10, 17, 60, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (12, 17, 60, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (3, 18, 20, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (5, 18, 50, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (6, 18, 100, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (3, 19, 20, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (5, 19, 50, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (6, 19, 100, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (7, 20, 100, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (8, 20, 150, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (24, 20, 10, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (23, 21, 20, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (20, 21, 20, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (17, 21, 50, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (19, 22, 20, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (18, 22, 20, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (21, 23, 20, NULL, NULL, NULL)
--INSERT [dbo].[PurchaseOrderItem] ([ItemID], [PurchaseOrderID], [RequestedQuantity], [ActualQuantity], [ReceivedQuantity], [UnitPrice]) VALUES (14, 23, 20, NULL, NULL, NULL)


--INSERT [dbo].[Requisition] ([ReqNumber], [RequesterID], [ReqDate], [Status], [ApprovedRejectedByID], [RecieveByID], [DepartmentID], [Remark], [DisbursementID]) VALUES (N'1536029349', 1, CAST(N'2017-01-31' AS Date), N'Approved', 0, 1, 1, N'', NULL)
--INSERT [dbo].[Requisition] ([ReqNumber], [RequesterID], [ReqDate], [Status], [ApprovedRejectedByID], [RecieveByID], [DepartmentID], [Remark], [DisbursementID]) VALUES (N'1169811729', 1, CAST(N'2017-01-31' AS Date), N'Approved', 0, 1, 2, N'', NULL)
--INSERT [dbo].[Requisition] ([ReqNumber], [RequesterID], [ReqDate], [Status], [ApprovedRejectedByID], [RecieveByID], [DepartmentID], [Remark], [DisbursementID]) VALUES (N'968993744 ', 1, CAST(N'2017-01-31' AS Date), N'Approved', 0, 1, 3, N'', NULL)
--INSERT [dbo].[Requisition] ([ReqNumber], [RequesterID], [ReqDate], [Status], [ApprovedRejectedByID], [RecieveByID], [DepartmentID], [Remark], [DisbursementID]) VALUES (N'2020240697', 1, CAST(N'2017-01-31' AS Date), N'Approved', 0, 1, 4, N'', NULL)
--INSERT [dbo].[Requisition] ([ReqNumber], [RequesterID], [ReqDate], [Status], [ApprovedRejectedByID], [RecieveByID], [DepartmentID], [Remark], [DisbursementID]) VALUES (N'91121120  ', 1, CAST(N'2017-01-31' AS Date), N'Approved', 0, 1, 5, N'', NULL)
--INSERT [dbo].[Requisition] ([ReqNumber], [RequesterID], [ReqDate], [Status], [ApprovedRejectedByID], [RecieveByID], [DepartmentID], [Remark], [DisbursementID]) VALUES (N'1879604454', 1, CAST(N'2017-01-31' AS Date), N'Approved', 0, 1, 5, N'', NULL)
--INSERT [dbo].[Requisition] ([ReqNumber], [RequesterID], [ReqDate], [Status], [ApprovedRejectedByID], [RecieveByID], [DepartmentID], [Remark], [DisbursementID]) VALUES (N'2075370209', 1, CAST(N'2017-01-31' AS Date), N'Approved', 0, 1, 4, N'', NULL)
--INSERT [dbo].[Requisition] ([ReqNumber], [RequesterID], [ReqDate], [Status], [ApprovedRejectedByID], [RecieveByID], [DepartmentID], [Remark], [DisbursementID]) VALUES (N'140366677 ', 1, CAST(N'2017-01-31' AS Date), N'Approved', 0, 1, 3, N'', NULL)
--INSERT [dbo].[Requisition] ([ReqNumber], [RequesterID], [ReqDate], [Status], [ApprovedRejectedByID], [RecieveByID], [DepartmentID], [Remark], [DisbursementID]) VALUES (N'1072126022', 1, CAST(N'2017-01-31' AS Date), N'Approved', 0, 1, 2, N'', NULL)
--INSERT [dbo].[Requisition] ([ReqNumber], [RequesterID], [ReqDate], [Status], [ApprovedRejectedByID], [RecieveByID], [DepartmentID], [Remark], [DisbursementID]) VALUES (N'1453344475', 1, CAST(N'2017-01-31' AS Date), N'Approved', 0, 1, 1, N'', NULL)






--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (1, 1, 1, 1, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (1, 4, 3, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (2, 6, 2, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (2, 5, 4, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (2, 1, 2, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (2, 45, 4, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (3, 1, 3, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (3, 4, 5, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (4, 5, 5, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (4, 7, 10, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (4, 1, 10, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (4, 45, 6, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (5, 1, 1, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (5, 45, 2, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (5, 4, 2, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (5, 5, 2, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (6, 1, 2, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (6, 45, 3, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (6, 4, 7, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (7, 5, 3, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (7, 7, 5, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (7, 6, 2, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (8, 45, 5, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (9, 58, 5, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (9, 41, 1, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (9, 3, 3, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (9, 45, 3, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (10, 1, 3, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (10, 48, 3, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (10, 58, 3, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (10, 67, 3, NULL, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RequisitionItem] ([ReqID], [ItemID], [NeededQuantity], [ApprovedQuantity], [RetirevedQuantity], [DisbursedQuantity], [RetrievalID], [IsOutstanding]) VALUES (10, 45, 3, NULL, NULL, NULL, NULL, NULL)








INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (1, 45, NULL, N'#B-001')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (2, 700, NULL, N'#B-002')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (3, 50, NULL, N'#B-002')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (4, 150, NULL, N'#B-002')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (5, 150, NULL, N'#B-002')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (6, 300, NULL, N'#B-002')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (7, 300, NULL, N'#B-002')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (8, 300, NULL, N'#B-002')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (9, 250, NULL, N'#B-002')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (10, 150, NULL, N'#B-006')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (11, 150, NULL, N'#B-006')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (12, 150, NULL, N'#B-006')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (13, 150, NULL, N'#B-006')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (14, 70, NULL, N'#B-003')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (15, 600, NULL, N'#B-006')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (16, 150, NULL, N'#B-006')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (17, 150, NULL, N'#B-006')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (18, 70, NULL, N'#B-006')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (19, 100, NULL, N'#B-007')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (20, 70, NULL, N'#B-007')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (21, 150, NULL, N'#B-007')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (22, 150, NULL, N'#B-007')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (23, 100, NULL, N'#B-007')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (24, 15, NULL, N'#B-007')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (25, 70, NULL, N'#B-007')
INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (26, 40, NULL, N'#B-007')




--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (1, 45, NULL, N'#B-001')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (2, 45, NULL, N'#B-002')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (3, 45, NULL, N'#B-002')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (4, 45, NULL, N'#B-002')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (5, 45, NULL, N'#B-002')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (6, 45, NULL, N'#B-002')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (7, 45, NULL, N'#B-002')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (8, 45, NULL, N'#B-002')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (9, 45, NULL, N'#B-002')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (10, 45, NULL, N'#B-006')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (11, 45, NULL, N'#B-006')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (12, 45, NULL, N'#B-006')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (13, 45, NULL, N'#B-006')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (14, 45, NULL, N'#B-003')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (15, 45, NULL, N'#B-006')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (16, 45, NULL, N'#B-006')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (17, 45, NULL, N'#B-006')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (18, 45, NULL, N'#B-006')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (19, 45, NULL, N'#B-007')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (20, 45, NULL, N'#B-007')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (21, 45, NULL, N'#B-007')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (22, 45, NULL, N'#B-007')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (23, 45, NULL, N'#B-007')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (24, 45, NULL, N'#B-007')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (25, 45, NULL, N'#B-007')
--INSERT [dbo].[StockCard] ([ItemID], [OnHandQuantity], [Remarks], [BinNumber]) VALUES (26, 45, NULL, N'#B-007')
