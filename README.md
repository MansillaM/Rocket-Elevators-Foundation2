<b>In this week consolidation week i created new REST api for my intervention table.</b>

<br>

-Here is my postman collection --> https://www.getpostman.com/collections/aade64e31febaaf268e9

ps. before you move on please note that on my video i said that the put request wasnt updated but you can clearly see it on the postman.

-Here is a visual presentation of it:
```
{
	"info": {
		"_postman_id": "981d6ce3-4b4f-4223-baf3-975a1cf39f23",
		"name": "InterventionsGet&PutRequest",
		"schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json",
		"_exporter_id": "21930815"
	},
	"item": [
		{
			"name": "PutRequest2",
			"request": {
				"method": "PUT",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{\"id\":2,\"customer_id\":2,\"building_id\":2,\"battery_id\":2,\"column_id\":2,\"elevator_id\":2,\"employee_id\":2,\"start_date\":\"2022-07-28T23:06:27\",\"end_date\":\"2023-07-28T23:06:27\",\"result\":\"Completed\",\"report\":\"Aperiam dolore qui. Omnis modi dolorem. Sit non rerum.\",\"status\":\"InProgress\",\"created_at\":\"2022-07-28T23:06:27\",\"updated_at\":\"2022-07-28T23:06:27\"}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:8888/api/interventions/2",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "8888",
					"path": [
						"api",
						"interventions",
						"2"
					]
				}
			},
			"response": []
		},
		{
			"name": "PutRequest1",
			"request": {
				"method": "PUT",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{\"id\":3,\"customer_id\":3,\"building_id\":3,\"battery_id\":3,\"column_id\":3,\"elevator_id\":3,\"employee_id\":3,\"start_date\":\"2022-07-28T23:06:28\",\"end_date\":null,\"result\":\"Incomplete\",\"report\":\"Culpa ut porro. Aut consequatur sunt. Et omnis dolorem.\",\"status\":\"InProgress\",\"created_at\":\"2022-07-28T23:06:28\",\"updated_at\":\"2022-07-28T23:06:28\"}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:8888/api/interventions/3",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "8888",
					"path": [
						"api",
						"interventions",
						"3"
					]
				}
			},
			"response": []
		},
		{
			"name": "GetRequest",
			"request": {
				"method": "GET",
				"header": [],
				"url": {
					"raw": "https://localhost:8888/api/interventions",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "8888",
					"path": [
						"api",
						"interventions"
					]
				}
			},
			"response": []
		}
	]
}
```
