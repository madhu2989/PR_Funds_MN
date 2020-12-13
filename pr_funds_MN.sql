create table fund_list
(id int primary key,
name varchar(25),
mobile_no bigint,
loan_amnt money,
instl_paid int,
balance_amnt money,
dt datetime);

create table yarige_fund 
(sl_no int identity(1,1) primary key ,
name varchar(25),
fn_taken_dt datetime
)

create table trans_fund
(
sl_no int identity(1000,1) primary key,
who_trans varchar(25),
trans_type int,
amnt money,
trans_dt datetime,
avl_balance money
)
------------------------------------------------------------



insert into fund_collection_new(name,mobile_no,dt) values('Madhu',326322,'02/02/2015')
delete fund_collection
truncate table trans_fund fund_collection_new select * from trans_fund fund_collection_new trans_fund   
trans_fund  fund_amount  avl_fund    avl_fund  avl_fund     avl_fund fund_collection_new
exec sp_fund_collection_new 500,'Madhu',99027,25000,0,0,0,'02/02/2014',0,0,0
delete fund_collection_new where id=503
select*from fund_collection_new
---------------this is right--------------------
---------------------available funs-----------------------------------------------
create table avl_fund
(sl_no int identity(1,1) primary key ,avl_fund_ money)
 
alter proc sp_avl_fund
(@avl_fund_ money)
as
begin
update avl_fund set avl_fund_= avl_fund_+@avl_fund_ 
where sl_no=1
end

insert into avl_fund values (0)

update avl_fund set avl_fund_=0 where sl_no=1
execute sp_avl_fund -10909300.00

select *from avl_fund


create proc sp_checkbal
as
begin
select avl_fund_ from avl_fund
end

select * from avl_fund
-----------------------------------------------------------------------------------------------------------


exec sp_fund_amount


-----------new add member table--------------------
create table new_addmember_only(
id int identity (500,1) primary key,
name varchar(25),
mobile_no bigint,
dt datetime)


alter proc sp_new_addmember_only
(@id int,
@name varchar(30),
@mobile_no bigint,
@dt datetime,
@idout int out)
as
if(@id=0)
begin
insert into new_addmember_only(name,mobile_no,dt) 
values (@name,@mobile_no,@dt)
set @idout=@@identity
end
else
begin
update new_addmember_only
set name=@name,mobile_no=@mobile_no
where id=@id
set @idout=@id
end

exec sp_new_addmember_only 0,'Manaswini',9742070071,'08-20-2018',0

create proc sp_view_new_addmember_only
as
begin
select * from new_addmember_only
end

alter proc sp_view_new_addmember_byid
@id int
as
begin
select * from new_addmember_only where id=@id
end

create proc sp_members_checkname
@name varchar(20)
as 
begin
select name from new_addmember_only where name=@name 
end;
      ------after pressing details list--------------
create table funds_ofMember(
loan_id int identity (1,1) primary key,
id int,
name varchar(50),
loan_amnt money,
balance_amt money,
no_ofdue int,
dt datetime)

insert into funds_ofMember values (500,'Madhu 1',100000,100000,0,'02-02-2018')
select * from funds_ofMember fund_collection_new  
exec sp_funds_ofMember 4,500,'Madhu 4',100000,1000,0,0,'09-20-2018',0,0,0


alter proc sp_funds_ofMember
(@loan_id int,
@id int,
@name varchar(50),
@loan_amt money,
@inst_amt money,
@bal_amt money out,
@no_ofdue int,
@dt datetime,
@trans_type int out,
@sl_no int out,
@avl_bal money out,
@loan_idout int out)
as
if(@loan_id=0 and @loan_amt!=0 and @inst_amt=0)
begin
set @trans_type=-1
set @avl_bal=(select avl_fund_ from avl_fund)+(@loan_amt*@trans_type)
set @bal_amt=@loan_amt
insert into funds_ofMember values
(@id,@name,@loan_amt,@bal_amt,@no_ofdue,@dt)
set @loan_idout=@@identity
insert into trans_fund values(@name,@trans_type,@loan_amt,@dt,@avl_bal)
set @sl_no=@@identity
update new_addmember_only
set dt=@dt
where id=@id
update avl_fund
set avl_fund_=@avl_bal
end
else
begin
set @trans_type=1
set @avl_bal=(select avl_fund_ from avl_fund)+(@inst_amt*@trans_type)
set @bal_amt=(((select balance_amt from funds_ofMember where loan_id=@loan_id)-@inst_amt)+(@no_ofdue*0.002*@loan_amt))
update funds_ofMember
set balance_amt=@bal_amt,no_ofdue=(no_ofdue+@no_ofdue),dt=@dt
where loan_id=@loan_id
set @loan_idout=@loan_id
insert into trans_fund values(@name,@trans_type,@inst_amt,@dt,@avl_bal)
set @sl_no=@@identity
update new_addmember_only
set dt=@dt
where id=@id
update avl_fund
set avl_fund_=@avl_bal
end

create table valuesto_sp_funds_ofMember
(loan_id int primary key,
id int,
name varchar(50),
loan_amt money,
inst_amt money,
no_ofdue int,
paid_dt datetime)



exec sp_funds_ofMember 4,500,'Madhu 1',100000,0,0,0,'08-24-2018',0,0,0,0

select * from funds_ofMember

create proc sp_view_funds_ofMember
as
begin
select * from funds_ofMember
end

create proc sp_view_funds_ofMember_byid
@id int
as
begin
select * from funds_ofMember where id=@id
end

create proc sp_view_funds_ofMember_by_loanid
@loan_id int
as
begin
select * from funds_ofMember where loan_id=@loan_id
end

create proc sp_delete_funds_ofMember_by_loanid
@loan_id int
as
begin
delete from funds_ofMember where loan_id=@loan_id
end

create proc sp_funds_ofMember_for_edit
(@loan_id int,
@name varchar(50))
as
begin
update funds_ofMember
set name=@name
where loan_id=@loan_id
end

---------------------------------------------------------------------------
truncate table fund_collection_new
select *from fund_collection_new
update fund_collection_new set name='Ranganath P' where id=500

alter proc sp_fund_collection_new_addmember
(@id int,
@name varchar(30),
@mobile_no bigint,
@dt datetime,
@idout int out)
as
if(@id=0)
begin
insert into fund_collection_new(name,mobile_no,dt) 
values (@name,@mobile_no,@dt)
set @idout=@@identity
end

exec sp_fund_collection_new_addmember 0,'ma',95,'12/21/2125',0

truncate table select * from fund_collection_new
--update fund_collection_new 
--set name='Bassu',mobile_no=7406477593,loan_amnt=50000,balance_amt=48000,no_ofdue=0,dt=getdate()
--where id=500





alter proc sp_fund_collection_new
(@id int,
@name varchar(25),
@mobile_no bigint,
@loan_amt money,
@inst_amt money,
@no_ofdue int,
@dt datetime,
@trans_type int out,
@sl_no int out,
@avl_bal money out)
as
if(@loan_amt!=0 and @inst_amt=0)
begin
set @trans_type=-1
set @avl_bal=(select avl_fund_ from avl_fund)+(@loan_amt*@trans_type)
update fund_collection_new
set name=@name,mobile_no=@mobile_no,loan_amnt=@loan_amt,balance_amt=@loan_amt,no_ofdue=0,dt=@dt
where id=@id
insert into trans_fund values(@name,@trans_type,@loan_amt,@dt,@avl_bal)
set @sl_no=@@identity
update avl_fund
set avl_fund_=@avl_bal
end
else
begin
set @trans_type=1
set @avl_bal=(select avl_fund_ from avl_fund)+(@inst_amt*@trans_type)
update fund_collection_new
set name=@name,mobile_no=@mobile_no,loan_amnt=@loan_amt,balance_amt=((balance_amt-@inst_amt)+(@no_ofdue*0.002*@loan_amt)),no_ofdue=(no_ofdue+@no_ofdue),dt=@dt
where id=@id
insert into trans_fund values(@name,@trans_type,@inst_amt,@dt,@avl_bal)
set @sl_no=@@identity
update avl_fund
set avl_fund_=@avl_bal
end
--------------------TABLE FOR SO MANY FUNDS FOR A MEMBER------------------------------------

-----------only delete------------------------------------------------------------------------
create proc sp_deleteMember
@id int
as
begin
delete fund_collection_new where id=@id
end

-----------only edit------------------------------------------------------------------------
create proc sp_fund_collection_new_editonly
@id int,
@name varchar(25),
@mob_no bigint
as
begin
update fund_collection_new
set name=@name,mobile_no=@mob_no
where id=@id
end
exec sp_fund_collection_new_editonly 505,'m hjghv',8586859586
select *from fund_collection_new


create table full_valuestoprocedure
(id int primary key,
name varchar(25),
mobile_no bigint,
loan_amt money,
inst_amt money,
no_ofdue int,
paid_dt datetime)


select*from full_valuestoprocedure
------------------------------check name-----------------------------------------------------
alter proc sp_members_singlename
@name varchar(20)
as 
begin
select name from fund_collection_new where name=@name 
end;

exec sp_members_singlename 'Madhu'


-------------View for fund_collection_new-----------------------------------------
create proc sp_view_fund_collection_new
as
begin
select*from fund_collection_new
end

----------------View by id fund_collection_new-------------------------------------------------------------------
create proc sp_view_fund_collection_new_byidonly
@id int
as
begin
select*from fund_collection_new where id=@id
end

exec sp_view_fund_collection_new_byidonly 500
-------------View by name fund_collection_new--------------------------------------
create proc sp_view_fund_collection_new_byname
@name varchar(25)
as
begin
select*from fund_collection_new where name=@name
end

exec sp_view_fund_collection_new_byname 'madhu'
----------------------------------------------------------------------------------------


----------------------depsit withdraw------------------------------------------------------------------
create table trans_type
(trans_id int primary key,
trans_type char(10))

insert into trans_type values (-1,'Withdraw')

select * from trans_type
--------------------------------return no of days-----------
SELECT DATEDIFF(DAY, select trans_dt from trans_fund order by desc where id=@id and select Max(trans_dt), t.LastTdate) AS 'tpFactor'
FROM @tblTransfund t

alter proc sp_no_ofweeks
@name varchar(20),
@date datetime
as
begin
select DateDiff(week,(select Max(trans_dt) from trans_fund where who_trans=@name),@date) as 'No_ofWeek'
end

select DateDiff(week,('2018-09-03 00:00:00.000'),'2018-09-17 00:00:00.000') as 'No_ofWeek'

select DateDiff(week,(07/04/2018,getdate()) as 'No_ofWeek'
select DateDiff(week,(select Max(trans_dt) from trans_fund where who_trans='bassu'),'2018-09-16 00:00:00.000') as 'No_ofWeek'


exec sp_no_ofweeks 'Bassu'
--------------------------------------------------------------------------------------

select *from trans_fund
delete  trans_fund where sl_no=1012
update trans_fund set trans_dt='08-05-2018' where sl_no=1019
create proc sp_viewmembers
as
begin
select *from fund_members
end

create proc sp_viewmembers_byname
@name varchar(30)
as
begin
select *from fund_members where name=@name
end

exec sp_viewmembers_byname 'madhu'
select *from fund_members trans_fund

alter proc sp_members
as 
begin
select name from fund_members
end;



alter proc sp_members_joinwithloanamt
as
begin

select m.id,m.name,m.cont_num,m.adress,t.amnt from  trans_fund t 
right outer join fund_members m
on m.name=t.who_trans
where t.amnt>24999 
end

select * from fund_members





exec sp_members_joinwithloanamt

select*from trans_fund



create table trans_fund
(
sl_no int identity(1000,1) primary key,
who_trans varchar(25),
trans_type int,
amnt money,
trans_dt datetime,
avl_balance money
)

alter proc sp_trans_fund
(@sl_no int out,
@who_trans varchar(25),
@trans_type int,
@amnt money,
@trans_dt datetime,
@avl_balance money)
as
if(@sl_no=0)
begin
set @avl_balance=(select avl_fund_ from avl_fund)+(@amnt*@trans_type)
update  avl_fund set avl_fund_ =(select avl_fund_ from avl_fund) + (@amnt*@trans_type)
insert into trans_fund 		
values(
@who_trans ,
@trans_type,
@amnt ,
@trans_dt,
@avl_balance )
set @sl_no=@@identity
end

create proc sp_viewtrans_fund
as
begin
select *from trans_fund
end

create proc sp_viewtrans_fund_joined_deposit
as
begin
select t.sl_no,t.who_trans,w.trans_type,t.amnt,t.trans_dt,t.avl_balance from trans_fund t
join trans_type w on w.trans_id=t.trans_type
end


alter proc sp_viewtrans_fund_joined_deposit_byId
@id int
as
begin
select t.sl_no,t.who_trans,w.trans_type,t.amnt,t.trans_dt,t.avl_balance,i.id from trans_fund t
join trans_type w on w.trans_id=t.trans_type
join funds_ofMember i on i.name=t.who_trans where i.id=@id
end

exec sp_viewtrans_fund_joined_deposit_byId 500


-------------------trans by date-------------------------------------------------
create table value_tosearch
(dt datetime)

alter proc sp_viewtrans_bydate
@date datetime
as
begin
select * from trans_fund where trans_dt=@date  
end


select count(*) as'no'from trans_fund where trans_type=-1
select * from trans_fund where trans_dt='2018-07-05'order by sl_no desc

select convert(varchar(11),getdate())

select * from trans_fund
---------------------------------------------------------------------------------
select t.sl_no,f.id,t.who_trans,t.trans_type,t.amnt,t.trans_dt,t.avl_balance from fund_members f
inner join trans_fund t
on t.who_trans=f.name


alter proc sp_viewtransfund_nameby
@name varchar(30)
as
begin
select * from trans_fund where who_trans=@name and trans_type=-1 and sl_no = (SELECT MAX(sl_no)  FROM trans_fund)
end

exec sp_viewtransfund_nameby 'Niranjan'

exec sp_trans_fund 0,'Niranjan',-1,1000,'06/30/2018',0

----------------------------Login------------------------------------------------------
create table fund_login_onlyfor_signup
(sl_no int identity(1,1) primary key,
username varchar(20),
pass_word varchar(20),
con_pass_word varchar(20),
user_roleid int,
Name varchar(20))



create table fund_login
(sl_no int identity(1,1) primary key,
username varchar(20),
pass_word varchar(20),
user_roleid int,
Name varchar(20))

create proc sp_fund_login_insert
(@sl_no int,
@username varchar(20),
@pass_word varchar(20),
@user_roleid int,
@Name varchar(20),
@sl_noout int out)
as
if(@sl_no=0)
begin
insert into fund_login values
(@username,
@pass_word,
@user_roleid,
@Name)
set @sl_noout=@@identity
end
else
begin
update fund_login
set username=@username,pass_word=@pass_word,user_roleid=@user_roleid,Name=@Name
where sl_no=@sl_no
set @sl_noout=@sl_no
end

exec sp_fund_login_insert 0,'r','r',2,'Ranga',0



select * from fund_login
truncate table fund_login
insert into fund_login values('m','m',1,'Madhu')

create proc sp_fund_login_
@userName_ varchar(20)
as
begin
select * from fund_login where username=@userName_
end

create proc sp_view_fund_login
as
begin
select * from fund_login
end

create proc sp_fund_login_delete
@sl_no int
as
begin
delete  fund_login where sl_no=@sl_no
end


exec sp_fund_login 'm'

----------------------------------------------------------------------------------------------------
create table fund_collection
(id int identity(1000,1) primary key,
name varchar(25),
mobile_no bigint,
loan_amnt money,
balance_amnt money,
no_ofdue int DEFAULT 0,
dt datetime);

drop TABLE fund_collection 
select * from full_
create table full_
(id int primary key,
name varchar(25),
mobile_no bigint,
loan_amt money,
inst_amt money,
paid_dt datetime,
no_ofdue int,trans_type int)

alter proc sp_fund_collection_weekly_new
(@id int,
@name varchar(25),
@mobile_no bigint,
@loan_amt money,
@inst_amt money,
@bal_amt money out,
@paid_dt datetime,
@no_ofdue int,
@idout int out,
@sl_no int out,
@trans_type int,
@avl_balance money out)
as
if((select name from fund_collection)!=@name)
begin
--set @loan_amt = (select amnt from trans_fund where who_trans=@name and trans_type=-1 and sl_no = (SELECT MAX(sl_no)  FROM trans_fund))
set @bal_amt= @loan_amt-@inst_amt
set @avl_balance=(select avl_fund_ from avl_fund)+(@inst_amt*@trans_type)
insert into fund_collection values
(@name,@mobile_no,@loan_amt,@bal_amt,@no_ofdue,getdate())
set @idout=@@identity
insert into trans_fund values
(@name,@trans_type,@inst_amt,getdate(),@avl_balance)
set @sl_no=@@identity
end
else
begin
set @avl_balance=(select avl_fund_ from avl_fund)+(@inst_amt*@trans_type)
update fund_collection
set name=@name,mobile_no=@mobile_no,loan_amnt=@loan_amt,balance_amnt=balance_amnt-@inst_amt,
no_ofdue=@no_ofdue,dt=getdate()

where name=@name
set @idout=@id
insert into trans_fund values
(@name,@trans_type,@inst_amt,getdate(),@avl_balance)
set @sl_no=@@identity
end



exec sp_fund_collection

exec sp_fund_collection 1000,'Madd',9902700647,0,500,0,'07/01/2018',0,1000
select *from trans_fund
select* from fund_members
select *from fund_collection_new

update fund_collection_new set loan_amnt=100000,balance_amt=100000 where id=553

delete  trans_fund where sl_no=1000
truncate table trans_fund
truncate table fund_members
truncate table fund_collection
