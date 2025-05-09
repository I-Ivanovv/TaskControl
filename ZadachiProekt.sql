CREATE DATABASE TaskList
USE TaskList

CREATE TABLE Status(
	status_id INT IDENTITY(1,1) PRIMARY KEY,
	status VARCHAR(50) NOT NULL
	)

CREATE TABLE Priority(
	priority_id INT IDENTITY(1,1) PRIMARY KEY,
	priority VARCHAR(50) NOT NULL
	)

CREATE TABLE Tasks(
	task_id INT IDENTITY(1,1) PRIMARY KEY,
	task VARCHAR(50) NOT NULL UNIQUE,
	status_id INT NOT NULL,
	priority_id INT NOT NULL,
	due_date DATE NOT NULL,
	created_at DATE NOT NULL,
	FOREIGN KEY(status_id) REFERENCES Status(status_id),
	FOREIGN KEY(priority_id) REFERENCES Priority(priority_id)
	)


CREATE TABLE People(
	person_id INT IDENTITY(1,1) PRIMARY KEY,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	age INT NOT NULL,
	phone_number VARCHAR(50),
	)

CREATE TABLE Task_People(
	task_id INT,
	person_id INT,
	time_assigned DATE NOT NULL,
	PRIMARY KEY(task_id,person_id),
	FOREIGN KEY(task_id) REFERENCES Tasks(task_id),
	FOREIGN KEY(person_id) REFERENCES People(person_id)
	)
	

CREATE TABLE Category(
	category_id INT IDENTITY(1,1) PRIMARY KEY,
	category_name VARCHAR(50) NOT NULL UNIQUE,
	)

CREATE TABLE Task_Category(
	task_id INT,
	category_id INT,
	PRIMARY KEY(task_id,category_id),
	FOREIGN KEY(task_id) REFERENCES Tasks(task_id),
	FOREIGN KEY(category_id) REFERENCES Category(category_id)
	)