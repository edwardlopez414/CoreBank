
# CoreBankAPI

Corebank api es una api con los requerimientos compartidos por grupo lafice, como prueba al puesto de desarrollador backend.

# Despliegue
clona el repositorio https://github.com/edwardlopez414/CoreBank.git

una ves clonado ejecuta el proyecto en Visual estudio.

puedes probar directamente los endpoints desde swagger o pudesde consumir los endpoints desde postman.

Si deseas empezar con una db limpia borra la carpeta Migrations y el archivo banco.db .

ejecueta los comando en el orden siguiente.
 dotnet ef migrations add Inicial  luego 
 dotnet ef database update

## API Reference

#### Crear perfil del cliente
```http
  POST /api/User/create
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `firstName` | `string` | **Required**. Primer nombre |
| `middleName` | `string` | **Required**. segundo Nombre|
| `lastName` | `string` | **Required**. Primer apellido|
| `lastName2` | `string` | **Required**. Segundo Apellido|
| `idtype` | `string` | **Required**. Tipo de identificacion|
| `idnumber` | `string` | **Required**. Numero de Identificacion|
| `birthdate` | `DateTime` | **Required**. Fecha de Nacimiento|
| `gender` | `string` | **Required**. Sexo|
| `income` | `int` | **Required**. Ingreso por mes en NIO |

#### Crear cuenta Bancaria

```http
  POST /api/Account/create
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `userId`      | `int` | **Required**. Id de Usuario|
| `initialBalance`      | `decimal` | **Required**. Balance inicial de la Cuenta|


#### Consultar Saldo

```http
  POST /api/Account/balance
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `identifier`      | `string` | **Required**. identificador unico de la cuenta|

#### Realizar deposito a la cuenta

```http
  POST /api/transaction/deposits
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `identifier` | `string` | **Required**. identificador unico de la cuenta|
| `amount`     | `decimal` | **Required**. monto de la transaccion|
| `description`| `string` | **Required**.descripcion del concepto de la transaccion|

#### Realizar retiro a la cuenta

```http
  POST /api/transaction/withdrawals
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `identifier` | `string` | **Required**. identificador unico de la cuenta|
| `amount`     | `decimal` | **Required**. monto de la transaccion|
| `description`| `string` | **Required**.descripcion del concepto de la transaccion|

#### Obtener el Hiatorial de transacciones y el balance alctual
```http
  POST /api/transaction/history
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `identifier` | `string` | **Required**. identificador unico de la cuenta|

