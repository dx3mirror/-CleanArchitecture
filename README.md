API для управления пациентами в системе CRM MED ANALIZ. Предоставляет возможность получения информации о пациентах, создания, обновления и удаления пациентов.

Методы
Получение списка всех пациентов
Запрос
GET /api/patients
Описание
Получение списка всех пациентов.

Параметры запроса
Отсутствуют.

Успешный ответ
Код: 200 OK
Тип содержимого: application/json
Ошибка
Код: 500 Internal Server Error
Описание: Ошибка сервера
Получение информации о пациенте по идентификатору
Запрос
GET /api/patients/{id}
Описание
Получение информации о пациенте по его идентификатору.

Параметры запроса
{id}: Идентификатор пациента (integer)
Успешный ответ
Код: 200 OK
Тип содержимого: application/json
Ошибка
Код: 404 Not Found
Описание: Пациент с указанным идентификатором не найден
Код: 500 Internal Server Error
Описание: Ошибка сервера
Создание нового пациента
Запрос
POST /api/patients
Описание
Создание нового пациента.

Параметры запроса
Тело запроса: Сущность PatientDTO в формате JSON
Успешный ответ
Код: 201 Created
Тип содержимого: application/json
Заголовок Location: URL созданного ресурса
Пример тела ответа (идентификатор созданного пациента):
1
Ошибка
Код: 400 Bad Request
Описание: Некорректные данные запроса
Код: 500 Internal Server Error
Описание: Ошибка сервера
Обновление информации о пациенте
Запрос
PUT /api/patients/{id}
Описание
Обновление информации о пациенте по его идентификатору.

Параметры запроса
{id}: Идентификатор пациента (integer)
Тело запроса: Сущность PatientDTO в формате JSON
Успешный ответ
Код: 204 No Content
Ошибка
Код: 400 Bad Request
Описание: Некорректные данные запроса
Код: 404 Not Found
Описание: Пациент с указанным идентификатором не найден
Код: 500 Internal Server Error
Описание: Ошибка сервера
Удаление пациента
Запрос
DELETE /api/patients/{id}
Описание
Удаление пациента по его идентификатору.
Параметры запроса
{id}: Идентификатор пациента (integer)
Успешный ответ
Код: 204 No Content
Ошибка
Код: 404 Not Found
Описание: Пациент с указанным идентификатором не найден
Код: 500 Internal Server Error
Описание: Ошибка сервера
