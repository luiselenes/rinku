    create datebase rinku;
create table Empleados(
    num_empleados bigint primary key  auto_increment,
    nombre varchar(50),
    appaterno varchar(50),
    apmaterno varchar(50),
    rol varchar(15),
    activo boolean
)

create table  Movimientos_mes(
    id_mv int primary key auto_increment,
    num_empleados int,
    mes varchar(10),
    catidad_entregas int,
    horas_trabajadas float,
    pago_entregas float,
    pago_bono float,
    vale float,
    ISR float, 
    sueldo_total float
)
