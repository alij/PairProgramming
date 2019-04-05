create table Owners 
(
Owner_ID int identity (1,1) not null,
first_name varchar (50) not null,
last_name varchar (50) not null,

constraint pk_owner_id primary key (Owner_ID)
)

create table Pets
(
Pet_ID int identity (1,1) not null,
OwnerID int not null,
pet_name varchar (50) not null,
type varchar (50) not null,
age int not null,
IsActive bit not null,


constraint pk_pet_id primary key (Pet_ID),
constraint chk_animal_type check (type in ('dog', 'cat', 'bird', 'reptile'))
)

create table Procedures
(
Procedure_ID int identity (1,1) not null,
procedure_name varchar (50) not null,
visit_date datetime not null,
cost int not null

constraint pk_procedure_id primary key (Procedure_ID)
)

create table Addresses
(
Address_ID int identity(1, 1) not null,
OwnerID int not null,
address1 varchar (50) not null,
address2 varchar (50),
city varchar (20) not null,
district varchar (20) not null,
country varchar (20) not null,
postalCode varchar (15) not null

constraint pk_address_id primary key (Address_ID)
)

create table Invoices
(
Invoice_ID int identity(1, 1) not null,
total int not null,
tax int not null,
date datetime not null

constraint pk_invoice_id primary key (Invoice_ID)
)

create table Pet_Invoices
(
PetID int not null,
InvoiceID int not null

constraint fk_PetID foreign key (PetID) references Pets(Pet_ID),
constraint fk_InvoiceID foreign key (InvoiceID) references Invoices(Invoice_ID)
)

create table Pet_Procedures
(
PetID int not null,
ProcedureID int not null,

constraint fk_PetId foreign key (PetID) references Pets(Pet_ID),
constraint fk_ProcedureId foreign key (ProcedureID) references Procedures(Procedure_ID)
)

Alter table Pets ADD foreign key (OwnerID) references Owners(Owner_ID)
Alter table Addresses Add foreign key (OwnerID) references Owners(Owner_ID)
Alter table Invoices add foreign key (PetID) references Pets(Pet_ID)
Alter table Invoices add foreign key (ProcedureID) references Procedures(Procedure_ID)

