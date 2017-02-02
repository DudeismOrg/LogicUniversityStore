delete from dbo.LUUser;
delete from dbo.Department;
delete from dbo.SupplierItem;
delete from dbo.Item;
delete from dbo.Supplier;
delete from dbo.CollectionPoint;
delete from dbo.category;
delete from dbo.role;

DBCC CHECKIDENT ('dbo.Role', RESEED, 1);
DBCC CHECKIDENT ('dbo.Category', RESEED, 1);
DBCC CHECKIDENT ('dbo.CollectionPoint', RESEED, 1);
DBCC CHECKIDENT ('dbo.Supplier', RESEED, 1);
DBCC CHECKIDENT ('dbo.SupplierItem', RESEED, 1);
DBCC CHECKIDENT ('dbo.Department', RESEED, 1);
DBCC CHECKIDENT ('dbo.LUUser', RESEED,1);
DBCC CHECKIDENT ('dbo.Item', RESEED, 1);
DBCC CHECKIDENT ('dbo.StockCard', RESEED, 1);




insert into dbo.Role (rolecode, rolename) values
('HOD', 'Department Head'),
('REP', 'Department Representative'),
('S-CLERK', 'Store Clerk'),
('S-SUPERVISOR', 'Store Supervisor'),
('S-MANAGER', 'Store Manager');

insert into dbo.Category(CategoryCode) 
values('Clip'),
('Envelope'),
('Eraser'),
('Excercise'),
('File'),
('Puncher'),
('Pad'),
('Paper'),
('Pen'),
('Ruler'),
('Scissors'),
('Tape'),
('Sharpener'),
('Shorthand'),
('Stapler'),
('Tacks'),
('Tparency'),
('Tray');

insert into dbo.CollectionPoint(CollectionPoint)
values('Stationery Store'),
('Management School'),
('Medical School'),
('Engineering School'),
('Science School'),
('Universty Hospital');

insert into dbo.Supplier 
(suppliercode, suppliername, suppliercontact, supplierphone, supplierfax, GSTRegistrationNumber, supplieraddress,MinDeliveryDay )
values
('ALPA', 'ALPHA Office Supplies', 'Ms Irene Tan', '64619928', '64612238', 'MR-8500440-2',
'Blk 1128, Ang Mo Kio Industrial Park #02-1108 Ang Mo Kio Street 62 Singapore 622262',5),
('CHEP', 'Cheap Stationer', 'Mr Soh Kway Koh', '63543234', '64742434', '',
'Blk 34, Clementi Road #07-02 Ban Ban Soh Building Singapore 110525',5),
('BANE', 'BANES Shop', 'Mr Loh Ah Pek', '64781234', '64792434', 'MR-8200420-2',
'Blk 124, Alexandra Road #03-04 Banes Building Singapore 550315',5),
('OMEG', 'OMEGA Stationery Supplier', 'Mr Ronnie Ho', '67671233', '67671234', 'MR-8555330-1',
'Blk 11, Hillview  Avenue #03-04 Singapore 679036',5);

insert into dbo.Item(ItemCode,ItemName, ItemDesc,UOM,BasePrice,CategoryID,ReorderLevel,ReorderQuantity)
values('C001','Clips Double 1"','Clips Double 1"','Dozen',20.00,6,50,30),
('E001','Envelope Brown(3"*6")','Envelope Brown(3"*6")','Each',0.40,7,600,400),
('E020','Eraser(hard)','Eraser(hard)','Each',1.00,8,50,20),
('E030','Excercise Book(100 pg)','Excercise Book(100 pg)','Each',5.00,9,100,50),
('F020','File Seperator','File Seperator','Set',50.00,5,100,50),
('F021','File-Blue Plain','File-Blue Plain','Each',50.00,5,200,100),
('F022','File-Blue with Logo','File-Blue with Logo','Each',50.00,5,200,100),
('F031','Folder Plastic Blue','Folder Plastic Blue','Each',50.00,5,200,150),
('F035','Folder Plastic Yellow','Folder Plastic Yellow','Each',50.00,5,200,150),
('P010','Pad Postit Memo 1"x2"','Pad Postit Memo 1"x2"','Packet',50.00,7,100,60),
('P011','Pad Postit Memo 1/2"x1"','Pad Postit Memo 1/2"x1"','Packet',50.00,7,100,60),
('P014','Pad Postit Memo 2"x4"','Pad Postit Memo 2"x4"','Packet',50.00,7,100,60),
('P013','Pad Postit Memo 2"x3"','Pad Postit Memo 2"x3"','Packet',50.00,7,100,60),
('P015','Note 2"x3"','Note 2"x3"','Pice',50.00,7,100,60);

insert into dbo.SupplierItem (itemid, supplierid, price, activesupplier, supplierpriority)
values
(1, 1, 30.00, 1, 1),
(2, 1, 30.00, 1, 1),
(3, 1, 30.00, 1, 1),
(4, 1, 30.00, 1, 1),
(5, 1, 30.00, 1, 1),
(6, 1, 30.00, 1, 1),
(7, 1, 30.00, 1, 1),
(8, 1, 30.00, 1, 1),
(9, 1, 30.00, 1, 1),
(10, 1, 30.00, 1, 1),
(11, 1, 30.00, 1, 1),
(12, 1, 30.00, 1, 1),
(13, 1, 30.00, 1, 1),
(1, 2, 30.00, 0, 2),
(2, 2, 30.00, 0, 2),
(3, 2, 30.00, 0, 2),
(4, 2, 30.00, 0, 2),
(5, 2, 30.00, 0, 2),
(6, 2, 30.00, 0, 2),
(7, 2, 30.00, 0, 2),
(8, 2, 30.00, 0, 2),
(9, 2, 30.00, 0, 2),
(10, 2, 30.00, 0, 2),
(11, 2, 30.00, 0, 2),
(12, 2, 30.00, 0, 2),
(13, 2, 30.00, 0, 2),
(1, 3, 30.00, 0, 2),
(2, 3, 30.00, 0, 2),
(3, 3, 30.00, 0, 2),
(4, 3, 30.00, 0, 2),
(5, 3, 30.00, 0, 2),
(6, 3, 30.00, 0, 2),
(7, 3, 30.00, 0, 2),
(8, 3, 30.00, 0, 2),
(9, 3, 30.00, 0, 2),
(10, 3, 30.00, 0, 2),
(11, 3, 30.00, 0, 2),
(12, 3, 30.00, 0, 2),
(13, 3, 30.00, 0, 2);

insert into dbo.Department(DepartmentCode,DepartmentName,ContactName,DepartmentPhone,DepartmentFax,HodID,CollectionPointID,RepresentativeID)
values('ENGL','English Dept','Mrs Pamela Kow','8742234','8921456',2,1,1),
('CPSC','Computer Science','Mr Wee Kian Fatt','8901235','8921457',4,2,3),
('COMM','Commerce Dept','Mr Mohd.Azman','8741284','8921256',6,3,5),
('REGR','Registrar Dept','Ms Helen Ho','8901266','8921465',8,4,7),
('ZOOL','Zoology Dept','Mr.Peter Tan Ah Meng','8901266','8921465',10,5,9);

insert into dbo.LUUser (username, firstname, lastname, password, roleid, email, address, departmentid)
values
('englreq', 'English', 'Department', 'password', 2, 'englreq@lu.edu.sg', 'Blk 123 Wonderful Street', 1),
('englhod', 'English', 'Department', 'password', 1, 'englhod@lu.edu.sg', 'Blk 123 Wonderful Street', 1),
('cpscreq', 'Computer Science', 'Department', 'password', 2, 'cpscreq@lu.edu.sg', 'Blk 123 Wonderful Street', 2),
('cpschod', 'Computer Science', 'Department', 'password', 1, 'cpschod@lu.edu.sg', 'Blk 123 Wonderful Street', 2),
('commreq', 'Commerce', 'Department', 'password', 2, 'commreq@lu.edu.sg', 'Blk 123 Wonderful Street', 3),
('commhod', 'Commerce', 'Department', 'password', 1, 'commhod@lu.edu.sg', 'Blk 123 Wonderful Street', 3),
('regrreq', 'Registrar', 'Department', 'password', 2, 'regrreq@lu.edu.sg', 'Blk 123 Wonderful Street', 4),
('regrhod', 'Registrar', 'Department', 'password', 1, 'regrhod@lu.edu.sg', 'Blk 123 Wonderful Street', 4),
('zoolreq', 'Zoology', 'Department', 'password', 2, 'zoolreq@lu.edu.sg', 'Blk 123 Wonderful Street', 4),
('zoolhod', 'Zoology', 'Department', 'password', 1, 'zoolhod@lu.edu.sg', 'Blk 123 Wonderful Street', 4);


insert into StockCard values(1,250,'valid','#B-001');
insert into StockCard values(2,250,'valid','#B-001');
insert into StockCard values(3,250,'valid','#B-001');
insert into StockCard values(4,250,'valid','#B-001');
insert into StockCard values(5,250,'valid','#B-001');
insert into StockCard values(6,250,'valid','#B-001');
insert into StockCard values(7,50,'valid','#B-001');
insert into StockCard values(8,50,'valid','#B-001');
insert into StockCard values(9,50,'valid','#B-001');
insert into StockCard values(10,50,'valid','#B-001');
insert into StockCard values(11,50,'valid','#B-001');
insert into StockCard values(12,50,'valid','#B-001');
insert into StockCard values(13,250,'valid','#B-001');
insert into StockCard values(14,250,'valid','#B-001');
