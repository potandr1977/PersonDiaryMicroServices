merge dbo.Persons as p
using
	(select
		@Id,
		@Name,
		@SurName,
		@HasFile
		) as ins (Id,Name,SurName,HasFile)
on (p.id = ins.id)
when matched then update set
					Name = ins.Name,
					SurName = ins.SurName,
					HasFile = ins.HasFile
when not matched then insert (Name,SurName,HasFile)
					values
						(
						ins.Name,
						ins.SurName,
						ins.HasFile
						)
output IIF($action='INSERT', Inserted.Id, ins.id);