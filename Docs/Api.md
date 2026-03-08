# e4 Academic API

- [Academic API](#e4-academic-api)
    - [Create Student](#create-student)
        - [Create Student Request](#create-student-request)
        - [Create Student Response](#create-student-response)
    - [Get Student](#get-student)
        - [Get Student Request](#get-student-request)
        - [Get Student Response](#get-student-response)
    - [Update Student](#update-student)
        - [Update Student Request](#update-student-request)
        - [Update Student Response](#update-student-response)
    - [Delete Student](#delete-student)
        - [Delete Student Request](#delete-student-request)
        - [Delete Student Response](#delete-student-response)

## Create Student

### Create Student Request

```json
POST : /students
```

```json
{
  "firstName": "Thabo",
  "lastName": "Mokoeana",
  "extraCurricularActivities": [
    "Tennis",
    "Chess",
    "Soccer"
  ],
  "courses": [
    "PHY001",
    "MAT003"
  ]
}
```

### Create Student Response

```
201 Created
```

```
Location : {{host}}/students/{{id}}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "studentNumber": 000000,
  "firstName": "Thabo",
  "lastName": "Mokoeana",
  "lastModifiedDateTime": "2026-04-06T12:00:00",
  "extraCurricularActivities": [
    "Tennis",
    "Chess",
    "Soccer"
  ],
  "courses": [
    "PHY001",
    "MAT003"
  ]
}
```

## Get Student

### Get Student Request

```json
GET : /students/{{id}}
```

### Get Student Response

```
200 Ok
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "studentNumber": 000000,
  "firstName": "Thabo",
  "lastName": "Mokoeana",
  "lastModifiedDateTime": "2026-04-06T12:00:00",
  "extraCurricularActivities": [
    "Tennis",
    "Chess",
    "Soccer"
  ],
  "courses": [
    "PHY001",
    "MAT003"
  ]
}
```

## Update Student

### Update Student Request

```json
PUT : /students/{{id}}
```

```json
{
  "firstName": "Thabo",
  "lastName": "Mokoeana",
  "extraCurricularActivities": [
    "Tennis",
    "Chess",
    "Soccer",
    "Swimming"
  ],
  "courses": [
    "PHY001",
    "MAT003",
    "CSC002"
  ]
}
```

### Update Student Response

```
204 No Content
```

## Delete Student

### Delete Student Request

```json
DELETE : /students/{{id}}
```

### Delete Student Response

```
204 No Content
```