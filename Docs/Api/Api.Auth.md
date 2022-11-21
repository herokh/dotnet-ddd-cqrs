# My Restaurant API

 - [My Restaurant API](#r-api)
    - [Auth](#auth)
        - [Register](#register)
            - [Register Request](#register-request)
            - [Register Response](#register-response)
        - [Login](#login)
            - [Login Request](#login-request)
            - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request
```json
{
    "firstName": "Test",
    "lastName": "Test",
    "email": "Test",
    "password": "1234"
}
```

### Register Response
```js
200 OK
```
```json
{
    "id": ""
}



### Login

```js
POST {{host}}/auth/login
```

