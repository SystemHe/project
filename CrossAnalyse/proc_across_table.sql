USE [test]
GO
/****** Object:  StoredProcedure [dbo].[proc_across_table]    Script Date: 08/09/2017 09:58:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[proc_across_table]
@TableName as varchar(50),
@NewColumn as varchar(50),
@GroupColumn as varchar(50),
@StatColumn as varchar(50),
@Operator as varchar(10)
as
declare @SQl as varchar(1000),@Column as varchar(50) Execute('declare cursor_new_column cursor for select distinct '+@NewColumn+' from '+@TableName+' for read only') 
begin 
set nocount ON
set @SQl='select '+@GroupColumn+','+@Operator+'('+@StatColumn+') as ['+@Operator+' of '+@StatColumn+']'
open cursor_new_column
while (0=0)
begin
fetch next from cursor_new_column into @Column
if(@@FETCH_STATUS<>0) break
set @SQl=@SQl+','+@Operator+'(case '+@NewColumn+' when '''+@Column+''' then '+@StatColumn+' Else null end) as ['+@Column+']'
end
set @SQl=@SQl+' from '+@TableName+' group by '+@GroupColumn
execute(@SQL)
print @SQL
if(@@ERROR<>0) return @@error
close cursor_new_column
deallocate cursor_new_column return 0
end
