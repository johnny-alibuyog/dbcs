use [csdb_prod];
go

update Plans.PensionPlanAvailOption
set AvailOptionDescription = 'He/She will get an amount of php 50,000.00 after 10 years'
where AvailOptionID = 1

update Plans.PensionPlanAvailOption
set AvailOptionDescription = 'He/She will be given php 100,000.00 after 20 years.'
where AvailOptionID = 2

update Plans.PensionPlanAvailOption
set AvailOptionDescription = 'Get some amount and the remaining amount will be given to him/her monthly. The amount to be given monthly will be agreed upon both the pensioer and coop''s Gen. Manager. This option will be considered as savings account thus earning an interest.'
where AvailOptionID = 3