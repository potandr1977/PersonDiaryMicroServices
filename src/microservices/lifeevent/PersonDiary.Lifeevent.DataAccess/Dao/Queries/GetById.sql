select
	p.Id    'Id',
	p.Name    'Name',
	p.SurName	'SurName',
	p.HasFile	'HasFile'
	from dbo.Persons p
	where df.Id = @Id;