use [csdb_prod];
go

update Plans.CollegeInsurancePlans
set MaturityDate = dateadd(year, AgingPeriod, PaymentCompletionDate)
