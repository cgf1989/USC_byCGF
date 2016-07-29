use [AthenaData]

go


/* ��һ������ʱ���ߺͱ�׼�汾��������������Ʒ���롢��ҵ��ҵ���롢��֯�����汾���ĵ��汾����Ŀ�汾��ҵ��汾*/
/*�����¼�Դ*/


Declare  @sid int;
select @sid=EventTimeID from  EventTimes where EventName='industryCode';
select @sid;

insert into StandardVersions values('��ҵ��׼',1,'V1.0',null,@sid) ;

select @sid=EventTimeID from  EventTimes where EventName='ProductStandard';
select @sid;

insert into StandardVersions values('��Ʒ��׼',1,'V1.0',null,@sid) ;


select @sid=EventTimeID from  EventTimes where EventName='administrative';
select @sid;

insert into StandardVersions values('������׼',1,'V1.0',null,@sid) ;
go

/*�����ѧרҵ��׼*/

insert into Specializeds (Code,SpecialName,Descript) select Code,Name,Descript  from ChinaStandard.dbo.Ac_Specialized;
Update  Specializeds set ParentCode =left(Code,4) where len(Code)>=6;
update Specializeds set ParentCode =left(Code,2) where len(Code)=4;
update Specializeds set ParentCode =null where len(Code)=2;
go


/*�����ѧרҵ���ֶ�*/

declare @st1t int ,@zdt varchar(50);
declare sfft cursor for select distinct p.ID,p.Code from Specializeds as p inner join Specializeds as ad1 on  p.Code=ad1.ParentCode;

open sfft;
fetch next from sfft into @st1t,@zdt;
while (@@FETCH_STATUS=0)
begin
update Specializeds set Parent=@st1t where Specializeds.ParentCode=@zdt;
fetch next from sfft into @st1t,@zdt;
end

close sfft;
deallocate sfft;
go



/*����administrativeDecode����*/
insert into Administrativecodes(DivisionCode,RegionName,ParentCode) select DivisionCode,RegionName,ParentCode from ChinaStandard.dbo.Ac_administrativecodes ;
declare @qh int;
select @qh=ID from StandardVersions where StandardVersions.Name='������׼';
select @qh;
update  Administrativecodes set StandardVersionID=@qh;
go

/*����administrativeCode���ֶ�*/
declare @st1 int ,@zd varchar(50);
declare sff cursor for select distinct p.SacID,p.DivisionCode from Administrativecodes as p inner join Administrativecodes as ad1 on  p.DivisionCode=ad1.ParentCode;

open sff;
fetch next from sff into @st1,@zd;
while (@@FETCH_STATUS=0)
begin

update Administrativecodes set Parent=@st1 where Administrativecodes.ParentCode=@zd;
fetch next from sff into @st1,@zd;
end

close sff;
deallocate sff;
go

/*������ҵ��׼*/

insert into IndustryCodes(code,Name,Descript,ParentCode) select Code,IName,Descript,parent from ChinaStandard.dbo.Ac_IndustryCodes;
declare @qh int;
select @qh=ID from StandardVersions where StandardVersions.Name='��ҵ��׼';
select @qh;
update  IndustryCodes set StandardVersionID=@qh;
go

/*������ҵ��׼���ֶ�*/
declare @st1 int ,@zd varchar(50);
declare sff cursor for select distinct p.ID,p.Code from IndustryCodes as p inner join IndustryCodes as ad1 on  p.Code=ad1.ParentCode;

open sff;
fetch next from sff into @st1,@zd;
while (@@FETCH_STATUS=0)
begin
update IndustryCodes set Parent=@st1 where IndustryCodes.ParentCode=@zd;
fetch next from sff into @st1,@zd;
end

close sff;
deallocate sff;


go



/*�����Ʒ��׼*/

insert into ProductStandards(ProductCode,Name,Descript,measureUnit,ParentCode) select ProductCode,PName,Descript,MeasureUnit, parent from ChinaStandard.dbo.Ac_ProductStandards;
declare @qh int;
select @qh=ID from StandardVersions where StandardVersions.Name='��Ʒ��׼';
select @qh;
update  ProductStandards set StandardVersionID=@qh;
go

/*�����Ʒ��׼���ֶ�*/
declare @st1 int ,@zd varchar(50);
declare sff cursor for select distinct p.ID,p.ProductCode from ProductStandards as p inner join ProductStandards as ad1 on  p.ProductCode=ad1.ParentCode;

open sff;
fetch next from sff into @st1,@zd;
while (@@FETCH_STATUS=0)
begin
update ProductStandards set Parent=@st1 where ProductStandards.ParentCode=@zd;
fetch next from sff into @st1,@zd;
end

close sff;
deallocate sff;


go

/*�������������ϢҪ�ؼ��������*/
insert into GBT_13923_2006s(Code,FeatureName,BussnessVerID) 
            select ChinaStandard.dbo.GBT13923ALL.ClassificationCode,ChinaStandard.dbo.GBT13923ALL.Feature,BussnessVers.ID 
			from ChinaStandard.dbo.GBT13923ALL,BussnessVers 
			where BussnessVers.Name='FirstVer' 
			Order By  ChinaStandard.dbo.GBT13923ALL.ClassificationCode ;
/*�������������ϢҪ�ؼ�������븸�ֶ�*/
declare @Pid int,@ocode varchar(50),@Xid int ;
declare cs cursor for select ID,Code from GBT_13923_2006s;
open cs
fetch next from cs into @Pid,@ocode;
while(@@FETCH_STATUS=0)
begin
  set @Xid=NULL;	
  select @Xid=ID from GBT_13923_2006s where Code=
      case
	     when Right(@ocode,5)='00000' then null
         when Right(@ocode,4)='0000' then left(@ocode,1)+'00000'
		 when Right(@ocode,2)='00' then left(@ocode,2)+'0000'
		 When right(@ocode,2)!='00' then left(@ocode,4)+'00'
	  end
  update GBT_13923_2006s set Parent=@Xid where Code=@ocode;

  fetch next from cs into @Pid,@ocode;
end
  close cs;
  deallocate cs;
go


/*�����õ����ͱ�׼*/

insert into Land_Types(Name,Content,[Level],Keys,Type_Code,ParentCode) select Name,Content,[level], Keys,T_ID,Parent from ChinaStandard.dbo.LandType;


/*�����õر�׼���ֶ�*/
declare @st1 int ,@zd varchar(50);
declare sff cursor for select distinct p.ID,p.Type_Code from Land_Types as p inner join Land_Types as ad1 on  p.Type_Code=ad1.ParentCode;

open sff;
fetch Next from sff into @st1,@zd;
while (@@FETCH_STATUS=0)
begin
update Land_Types set ParentID=@st1 where Land_Types.ParentCode=@zd;
fetch next from sff into @st1,@zd;
end

close sff;
deallocate sff;
go


/*��Ŀ����*/
insert into Project_Type values('������','����ľ����Ϊ�������Ŀ',null);
insert into Project_Type values('������','�Է�������Ϊ�������Ŀ',null);
insert into Project_Type values('��Ʒ��','�Բ�Ʒ��ӪΪ�������Ŀ',null);
insert into Project_Type values('������','δ��ȷ��',null);
/*�����̵����*/
insert into Taskgroups values('�칫����','��Ҫ�ṩ�칫�����');
insert into Taskgroups values('��������','��Ҫ�ṩ�������������');
insert into Taskgroups values('���̹���','��Ҫ�ṩ���������');


/*��������*/
declare @tgp int ;
select @tgp=ID from TaskGroups where Name='�칫����';
insert into Task_Type values('��������','\Iplugn\guang.dll',@tgp,'landmanage',NULL,null,'myde','v1.0',null,12321);
insert into Task_Type values('���ع���','\Iplugn\guang.dll',@tgp,'landmanage',NULL,null,'myde','v1.1',null,12321);
insert into Task_Type values('���̹���','\Iplugn\guang.dll',@tgp,'landmanage',NULL,null,'myde','v1.2',null,12321);
insert into Task_Type values('��ȫ����','\Iplugn\guang.dll',@tgp,'landmanage',NULL,null,'myde','v1.3',null,12321)
/*����״̬*/
insert into TaskStates values('�ƻ��ڼ�','�����Ѿ��ƻ�������û������','�ƻ�');
insert into TaskStates values('ִ���ڼ�','����ʼִ�У�����û�����','ִ��');
insert into TaskStates values('�����ڼ�','�����Ѿ���ɣ�����������','����');
insert into TaskStates values('��ɹ鵵','�����Ѿ��ƻ�������û������','�鵵');

go

/* ��֯���� */
insert into Organization_Type(Ocode,OName,Descript,ParentCode) select OCode,OName,Descript,ParentCode from ChinaStandard.dbo.organizationType;
declare @st1 int ,@zd varchar(50);
declare sff cursor for select distinct p.ID,p.Ocode from Organization_Type as p inner join Organization_Type as ad1 on  p.Ocode=ad1.ParentCode;

open sff;
fetch next from sff into @st1,@zd;
while (@@FETCH_STATUS=0)
begin
update Organization_Type set Parent=@st1 where Organization_Type.ParentCode=@zd;
fetch next from sff into @st1,@zd;
end

close sff;
deallocate sff;
go

/* ��֯������ϵ����*/
insert into Subordinates (Code,Name,Descript) select Code,Name,Descript from ChinaStandard.dbo.Subordinate;

/*�û�������Ϣ*/
insert into users values('tl001','8888','��һ��','340103190212012343','good','����');
insert into users values('tl002','8888','����','340103190212012343','good','����');
insert into users values('tl003','8888','����','340103190212012343','good','����');
insert into users values('tl004','8888','��С˫','340103190212012343','good','����');
insert into users values('tl005','8888','�Ժ콭','340103190212012343','good','����');
insert into users values('tl006','8888','��ҽ��','340103190212012343','good','����');
go

declare @Uid int;
select @Uid=users.ID from Users where users.UserName='tl001';
insert into Positions values('�ܾ���',@Uid,'GH001',1,NULL,Null,'zongjingli','this is ','zongshi','guangzhou','100038',Null);
select @Uid=users.ID from Users where users.UserName='tl002';
insert into Positions values('vic����',@Uid,'GH002',1,NULL,Null,'zonasdgjingli','tadsfis ','adfdshi','guangzhou','243243',Null);
select @Uid=users.ID from Users where users.UserName='tl003';
insert into Positions values('sdas����',@Uid,'GH003',1,NULL,Null,'zongjingli','gfasd ','zonadsfhi','guangzhou','53423',Null);
select @Uid=users.ID from Users where users.UserName='tl004';
insert into Positions values('adf����',@Uid,'GH004',1,NULL,Null,'zongjingli','reasdis ','zadsfgshi','guangzhou','42323',Null);


/* �ĵ����� */
insert into DocumentTypes values('��Ŀ����','����','���ǲ����õ�',null);
insert into DocumentTypes values('��ͬ��','�ݸ�','zheyeshiceshi',null);
insert into DocManageStates values('�鵵','finish');
insert into DocManageStates values('�����ĵ�','progress');
go

declare @vrel int;
select @vrel=EventTimeID from EventTimes where EventName='servceStandard'; 
select @vrel;

insert into BussnessVers values('FirstVer','ver1.0',@vrel);
go

insert into Pro_orgRelateType values('ҵ����λ','ҵ����λ',null);
insert into Pro_orgRelateType values('����λ','����ĵ�λ',null);
insert into Pro_orgRelateType values('��Ƶ�λ','��Ƶĵ�λ',null);
insert into Pro_orgRelateType values('ʩ����λ','ʩ���ֳ���λ',null);
insert into Pro_orgRelateType values('��Ӧ��','device or material',null);
insert into Pro_orgRelateType values('����λ','managerUnit',null);
insert into Pro_orgRelateType values('������λ','coop ',null);

go

declare @ls int;
select @ls=ID from Pro_orgRelateType where Name='ҵ����λ';
select @ls;
insert into Pro_orgRelateType values('���赥λ','����Ͷ�ʽ���ĵ�λ',@ls);
insert into Pro_orgRelateType values('��Ӫ��λ','������Ӫ�ĵ�λ',@ls);



select @ls=ID from Pro_orgRelateType where Name='��Ӧ��';
select @ls;
insert into Pro_orgRelateType values('���Ϲ�Ӧ��','����Ͷ�ʽ���ĵ�λ',@ls);
insert into Pro_orgRelateType values('�豸��Ӧ��','������Ӫ�ĵ�λ',@ls);

go





/*-- �����֯--*/
declare @ty int;
select @ty=ID from Organization_Type where OName='˽Ӫ�������ι�˾';
select @ty;
insert into Organizations values('716309097','�����к���������·11��'     ,'3814221','1993-06-01', null, '����ͼ֮��',1);
insert into Organizations values('716300987','�����д�Ԫ˧��'               ,'3815222','1994-06-02', null , '��Ԫ˧��',1);
insert into Organizations values('716301232','�������������˾'           ,'3815223','1994-06-02', null, '����',0);
go


/*--��д��˾������Ϣ--*/

declare @tyx int,@evt int,@uid int,@said int;
select @tyx=ID from Organizations where OrganizationCode='716309097';
select @tyx;
select @evt=EventTimeID from EventTimes where TimePoint='2012-01-02';
select @evt;
select @uid=Positions.ID from positions where Positions.Title='�ܾ���';
select @said=Administrativecodes.SacID from Administrativecodes  where Administrativecodes.DivisionCode='440103002103';
insert into OrganizBasics values('Tl001234','����������·���鴴��԰',@uid,'������ͬһ�ص�','11�Ŵ�¥','23490��','�����з�','��������',5,3,'���������̾�','2018-01-01','2011-11-09','����ʹ��ҵ������',null,1,4,3,@said,1);
go
/* ��Ӳ���ְ������*/
insert into Functions Values('����ְ��','�����������е��ĺ���ְ��','ceshi','ceshi',null);
insert into Functions Values('רҵְ��','�������ųе��ľ��弼��ְ��','��ʵ��ְ�ܵļ���Ҫ��','ceshi',null);
insert into Functions Values('����ְ��','�����������רҵְ�������еĹ���ְ��','��������','zheyang',null);
insert into Functions Values('һ��ְ��','�����������רҵ�ͺ���ְ������Ҫ��һ��ֻ����㱨','�ļ���ݵ�','������',null);
go

/* ��Ӳ��� */

Declare @ty1 int,@dep int;
select @ty1=ID from Organizations where OrganizationCode='716309097';
select @ty1;
insert into Departments values('�ܾ���칫��','�ܾ���칫�ұ��',null,'������������','�й����ǵ��廪',1,'ȡ��ʱ��',@ty1,null);

 
go
/*��������ְ��*/
declare @dep int,@fty int;
select @dep=ID from Departments where Name='�ܾ���칫��'
select @dep;
select @fty=ID from Functions where Name='����ְ��';
select @fty;
insert into DepartmentFunctions values ('�ƶ���˾ս�Լƻ�',1,@dep,@fty)
insert into DepartmentFunctions values ('ʵ�ֹ�˾Ŀ��ƻ�',1,@dep,@fty)
insert into DepartmentFunctions values ('�ලʵʩ�ƻ�',1,@dep,@fty)

select @dep=ID from Departments where Descript='�ܾ���칫��'
select @dep;
select @fty=ID from Functions where Name='רҵְ��';
select @fty;
insert into DepartmentFunctions values ('ָ�ӵ���Ҫ��',1,@dep,@fty)
insert into DepartmentFunctions values ('����Ҫ�ط�������',1,@dep,@fty)
insert into DepartmentFunctions values ('����Ҫ�صĻ���',1,@dep,@fty)

select @dep=ID from Departments where Descript='�ܾ���칫��'
select @dep;
select @fty=ID from Functions where Name='����ְ��';
select @fty;
insert into DepartmentFunctions values ('���ƻ�',1,@dep,@fty)
insert into DepartmentFunctions values ('����',1,@dep,@fty)
insert into DepartmentFunctions values ('����',1,@dep,@fty)
go

/*������λ*/
declare @gw int,@zhe int,@pID int,@spid int;
select @zhe=EventTimeID from EventTimes where TimePoint='2012-01-01';
select @zhe;

select @gw=ID from Departments where Descript='�ܾ���칫��';
select @gw;
insert into Posts values(Null,'�ܾ����λ',@gw,'����ȫ�湤��','��λ���',1,null);

select @pID=ID from Posts where Descript='����ȫ�湤��';
select @pID;

select @spid=ID from Specializeds where SpecialName='��Ϣ������ѧ';

insert into Postbasics values('�ܾ���','���߹�˾�ش�����','һ��','����','�߼�����ʦ',null,@zhe,@spid,@pID);

insert into PositionBasics values('Super','Super','20000','������','��˾�칫��',@zhe,@pID,null);

/* second*/
declare @gw1 int,@zhe1 int,@pID1 int ;
select @zhe1=EventTimeID from EventTimes where TimePoint='2012-01-01';
select @zhe1;

select @gw1=ID from Departments where Descript='�ܾ���칫��';
select @gw1;
insert into Posts values('bussboss',@gw,'���ܾ���','��λ���',1,null,null);

select @pID1=ID from Posts where Descript='���ܾ���';
select @pID1;
 
insert into Postbasics values('���ܾ���','Э�����߹�˾�ش�����','����','����','�߼�����ʦ',null,@zhe1,@spid,@pID1);
insert into PositionBasics values('Super','Super','18000','����ϵ','��˾�칫��' ,@zhe1,@pID1,null);


/* third*/
declare @gw2 int,@zhe2 int,@pID2 int ;
select @zhe2=EventTimeID from EventTimes where TimePoint='2012-01-01';
select @zhe2;

select @gw2=ID from Departments where Descript='�ܾ���칫��';
select @gw2;
insert into Posts values('�ܹ�',@gw,'�ܹ���λ','��λ���',1,null,null);

select @pID2=ID from Posts where Descript='�ܹ���λ';
select @pID2;
 

insert into Postbasics values('�ܹ�','���߹�˾�ش�������','һ��','�о���','�߼�����ʦ',null,@zhe2,@spid,@pID2);
insert into PositionBasics values('Super','Super','19000','������','��˾�칫��' ,@zhe2,@pID2,null);
go
 

/*���������λְ��*/
/*��һ��λ��һ��ְ��*/
declare @gwc int,@duid int,@eventtime int, @taskty int,@dfun int;

select @dfun=ID from DepartmentFunctions where Content='�ƶ���˾ս�Լƻ�';
select @dfun;

select @eventtime=EventTimes.EventTimeID from EventTimes where TimePoint='2012-01-01';
select @eventtime;

select @gwc=ID from Posts where Descript='�ܾ����λ';
select @gwc;

insert into Duties values('�ܾ���ĵ�һ��ְ��','�����Ĺ���','ְ����','������','���뷽��','������������','ע�ͺͱ��','��������',1,2);


select @duid =ID from duties where Descript='�ܾ���ĵ�һ��ְ��';
select @duid;
select @taskty=ID from Task_Type where TypeName='���ع���';
select @taskty;
insert into authorizationinfoes values(@gwc,@duid,1,'shaojinlin',null);
insert into DutyBasics values('���߹���','ȫ�渺��˾��ս�Ծ���','��������������','�г��İ취','����ķ�ʽ','���»�㱨',@duid,null,@eventtime,@taskty);

/*��һ��λ�ڶ���ְ��*/

insert into Duties values('�������','�ܾ���ĵڶ���ְ��','ְ����','erty','hgfhf','ghjghj','jhgo','��ʶ',null,@dfun);
select @duid =ID from duties where Descript='�ܾ���ĵڶ���ְ��';
select @duid;

insert into DutyBasics values('�������','ȫ�渺��˾�Ĳ�������','�����쵼����','����İ취','����ķ�ʽ','���»�㱨',@duid,null,@eventtime,@taskty);

/*��һ��λ������ְ��
insert into Duties values('�ܾ���ĵ�����ְ��','ְ����','ʿ���','������','��̫����','���ʵ�','utyty',1,@dfun);
select @duid =ID from duties where Descript='�ܾ���ĵ�����ְ��';
select @duid;

insert into DutyBasics values('�г�����','ȫ�渺��˾���г�����','��������������','�г��İ취','����ķ�ʽ','���»�㱨',@duid,null,@eventtime,@taskty);
go
*/
/*�ڶ���λ��һ��ְ��*/
declare @gwc int,@duid int,@eventtime int, @taskty int,@dfun int;

select @dfun=ID from DepartmentFunctions where Content='�ƶ���˾ս�Լƻ�';
select @dfun;
select @eventtime=EventTimes.EventTimeID from EventTimes where TimePoint='2012-01-01';
select @eventtime;

select @gwc=ID from Posts where Descript='���ܾ���';
select @gwc;
select @taskty=ID from Task_Type where TypeName='���ع���';
select @taskty;
/*
insert into Duties values('���ܾ���ĵ�һ��ְ��','ְ����',@dfun);
select @duid =ID from duties where Descript='���ܾ���ĵ�һ��ְ��';
select @duid;
*/
/*
insert into authorizationinfoes values(@gwc,@duid,1,'other',null);
insert into DutyBasics values('Э�����߹���','Э����˾��ս�Ծ���','��������������','�г��İ취','����ķ�ʽ','���ܾ���㱨',@duid,null,@eventtime,@taskty);

/*�ڶ���λ�ڶ���ְ��*/
insert into Duties values('���ܾ���ĵڶ���ְ��','ְ����',@dfun);
select @duid =ID from duties where Descript='���ܾ���ĵڶ���ְ��';
select @duid;

insert into DutyBasics values('�г�����','ʵʩ��˾�г�ս��','��������������','�г��İ취','����ķ�ʽ','���ܾ���㱨',@duid,null,@eventtime,@taskty);

/*�ڶ���λ������ְ��*/
insert into Duties values('���ܾ���ĵ�����ְ��','ְ����',@dfun);
select @duid =ID from duties where Descript='���ܾ���ĵ�����ְ��';
select @duid;

insert into DutyBasics values('Э�����ڹ���','Э�������˾���ڲ�������','��������������','�г��İ취','����ķ�ʽ','���ܾ���㱨',@duid,null,@eventtime,@taskty);
go


/*������λ��һ��ְ��*/
declare @gwc int,@duid int,@eventtime int,@taskty int,@dfun int;
select @eventtime=EventTimes.EventTimeID from EventTimes where TimePoint='2012-01-01';
select @eventtime;
select @dfun=ID from DepartmentFunctions where Content='�ƶ���˾ս�Լƻ�';
select @dfun;
select @gwc=ID from Posts where Descript='�ܹ���λ';
select @gwc;
select @taskty=ID from Task_Type where TypeName='���ع���';
select @taskty;/*
insert into Duties values('�ܹ��ĵ�һ��ְ��','ְ����',@dfun);
select @duid =ID from duties where Descript='�ܹ��ĵ�һ��ְ��';
select @duid;

insert into DutyBasics values('��������','ȫ�渺��˾�ļ���ս��','��������������','�г��İ취','����ķ�ʽ','���»�㱨',@duid,null,@eventtime,@taskty);
/*������λ�ڶ���ְ��*/
insert into Duties values('�ܹ��ĵڶ���ְ��','ְ����',@dfun);
select @duid =ID from duties where Descript='�ܹ��ĵڶ���ְ��';
select @duid;

insert into DutyBasics values('��������','ȫ�渺��˾�Ĺ����������','�����쵼����','����İ취','����ķ�ʽ','���»�㱨',@duid,null,@eventtime,@taskty);

/*������λ������ְ��*/
insert into Duties values('�ܹ��ĵ�����ְ��','ְ����',@dfun);
select @duid =ID from duties where Descript='�ܹ��ĵ�����ְ��';
select @duid;

insert into DutyBasics values('���й���','ȫ�渺��˾���г��ɻ����з�','��������������','�г��İ취','����ķ�ʽ','���»�㱨',@duid,null,@eventtime,@taskty);
*/
*/
/*����λ�����û�����Ϊ��˾��Ա */
declare @us int,@post int,@tim int;
select @us=users.ID from users where ActualName='��һ��';
select @us;
select @post=ID  from Posts where Descript='�ܾ����λ'
select @post;
select @tim=EventTimeID from EventTimes Where TimePoint='2012-01-03';
/*
insert into Employees values('zhaoyiman',@us,@post,'Tl001',1,@tim,null);

select @us=users.ID from users where ActualName='����';
select @us;
select @post=ID  from Posts where Descript='���ܾ���'
select @post;
insert into Employees values('zhaosi',@us,@post,'Tl002',1,@tim,null);

select @us=users.ID from users where ActualName='����';
select @us;
select @post=ID  from Posts where Descript='�ܹ���λ'
select @post;
insert into Employees values('zhangsan',@us,@post,'Tl003',1,@tim,null);
*/
go
Declare @tim int ,@pbase int;
select @tim=EventTimeID from EventTimes where TimePoint='2012-01-07';
select @tim;

/*������Ŀ����*/
insert into ProjectBaseManagers values(@tim,'���ٹ�·��Ŀ�������Ŀ','���޸��ٹ�·ԭʼ��Ŀ',null,'��Ŀ����');
select @pbase=ID from ProjectBaseManagers where ProjectRoot='���ٹ�·��Ŀ�������Ŀ';
select @pbase ;

insert into ProjectBaseManagers values(@tim,'���ٹ�·ʩ�����ȿ���','���޸��ٹ�·����',@pbase,'������Ŀ');
insert into ProjectBaseManagers values(@tim,'����Ŀ����','ʩ�����Ȼ���',@pbase,'��Ŀ����');
go
/*������Ŀ����*/
declare @ty int,@emp int,@basid int;
select @ty=ID from Project_Type where Name='������';
select @ty;
select @emp=ID from Employees where Employees.UserID !=null;
select @emp;
select @basid=ID from ProjectBaseManagers where name='���޸��ٹ�·����';
select @basid;

insert into Projects values('Projecttestone',@ty,'�����Ŀ�ɲ����ˣ������ǵļ����з��ĵ�һ��','2012-01-01','2015-01-01',null,@emp,@basid,1,1 );
insert into Projects values('Projecttexttwo',@ty,'���������Ŀ�ĵڶ�����Ŀ��ϣ������֧��','2012-01-01','2016-01-01',null,@emp,@basid,0,1);
go
/* ������Ŀ����֯�Ĺ�ϵ*/

declare @pr int,@pj int,@por int;
select @pr=ID from Pro_orgRelateType Where name='���赥λ';
select @pr;
select @pj=ID from projects Where IsBase=1;
select @pj;
select @por=ID from Organizations where Organizations.OrganizationCode='716309097'
select @por;
insert into projectRelateOrganizations values(@pj,@por,@pr);


/* ��д��Ŀ������Ϣ*/

insert  into projectbasics values(@pj,'���޸��ٹ�·','�㶫ʡ��·�������޹�˾','��·����ơ�ʩ��������',null);
declare @pjj int;
select @pjj=ID from projects Where IsBase=0;
select @pjj;
insert  into projectbasics values(@pjj,'�㶫ʡ��·�������޹�˾','��·����ơ�ʩ��������','��ͬ�ĵ�00123',null);

go

/* ��д������Ϣ*/
declare @taid int,@tasate int,@prj int;
select @taid=ID from Task_Type where TypeName='���ع���';
select @taid;
select @tasate=ID from TaskStates where State='ִ���ڼ�';
select @tasate;
select @prj=ID from Projects where Projects.StartTime='2012-01-01';
select @prj;

insert into Tasks values('��������','������������','��һ��','������������',@taid,@tasate,@prj,null,'2012-08-08','2012-08-08',null);
insert into Tasks values('���߹���','������ߵı��','��һ��','������������',@taid,@tasate,@prj,null,'2012-08-08','2013-08-08',null);
insert into Tasks values('��������','���������⳥','��һ��','������������',@taid,@tasate,@prj,null,'2012-08-08','2013-08-08',null);

go