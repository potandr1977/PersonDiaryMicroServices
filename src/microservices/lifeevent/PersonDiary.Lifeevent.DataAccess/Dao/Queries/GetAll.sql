select
	p.Id    'Id',
	p.Name    'Name',
	p.SurName	'SurName',
	p.HasFile	'HasFile'
	from dbo.Persons p
	order by 
	p.Id offset @pageSize * (@pageNo - 1) rows fetch next @pageSize rows only;
