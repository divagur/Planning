USE [Planning]
GO

CREATE TABLE [dbo].[functions](
	[id] [varchar](32) NOT NULL,
	[name] [varchar](120) NULL,
 CONSTRAINT [PK_functions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into functions(id, name)
values('Attr','Аттрибуты')

insert into functions(id, name)
values('DelayReasons','Причины задержки')

insert into functions(id, name)
values('Depositor','Депозиторы')

insert into functions(id, name)
values('Gate','Ворота')

insert into functions(id, name)
values('OperType','Типы операций')

insert into functions(id, name)
values('Settings','Настройка')

insert into functions(id, name)
values('TC','Транспортные компании')

insert into functions(id, name)
values('TimeSlot','Тайм слоты')

insert into functions(id, name)
values('TransporType','Типы ТС')

insert into functions(id, name)
values('UserGrp','Группы пользователей')

insert into functions(id, name)
values('Users','Пользователи')


