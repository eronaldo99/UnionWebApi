alter PROCEDURE PA_TABLE_ENTIDAD_GET_LAST_VERSION
@tblName nvarchar(50),
@xml xml
AS
--PA_TABLE_ENTIDAD_GET_LAST_VERSION 'DEPARTAMENTO','<ES><E Key="1" Version="AAAAAAAAB+4=" Deleted="false" /><E Key="2" Version="AAAAAAAAB+8=" Deleted="false" /><E Key="3" Version="AAAAAAAAB/A=" Deleted="false" /></ES>'
--PA_TABLE_ENTIDAD_GET_LAST_VERSION 'DEPARTAMENTO','<ES><E Key="2" Version="AAAAAAAAB+8=" Deleted="false" /><E Key="3" Version="AAAAAAAAB/A=" Deleted="false" /></ES>'

DECLARE @sql nvarchar(500);  

select p.E.value('@Key','int') as Id,p.E.value('@Version','timestamp') as rVersion,p.E.value('@Deleted','bit') rDeleted 
into #tParameter
from @xml.nodes('/ES/E') as p(E)

set @sql = N'SELECT a.* FROM '+ @tblName + ' a left join #tParameter b on a.Id=b.Id where a.version>isnull(b.rVersion,0) and (a.deleted=0 or isnull(b.rVersion,0)>0)';  

EXECUTE sp_executesql @sql

drop table #tParameter

/*si servidor registro deleted and local version =0 o no se esta consultando no devolver registro. 
Sd=1 and Lv=0  o   Sd=0 or Lv>0
*/
update departamento
set deleted=0
where id=1

	PA_TABLE_ENTIDAD_GET_LAST_VERSION 'DEPARTAMENTO','<ES />'	