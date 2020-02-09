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
					Id = ins.Id,
					Name = ins.Name,
					SurName = ins.SurName
when not matched then insert (Name,SurName,HasFile)
					values
						(ins.Id,
						ins.Name,
						ins.SurName,
						ins.HasFile
						);