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

constraint pk_procedure_id primary key (Procedure_ID)
)

create table Pet_Procedures
(
PetID int not null,
ProcedureID int not null,

constraint fk_PetId foreign key (PetID) references Pets(Pet_ID),
constraint fk_ProcedureId foreign key (ProcedureID) references Procedures(Procedure_ID)
)

Alter table Pets ADD foreign key (OwnerID) references Owners(Owner_ID)
