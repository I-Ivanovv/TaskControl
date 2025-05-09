USE TaskList

INSERT INTO [Status] (status)
VALUES ('Pending'),
	   ('In Progress'),
	   ('Completed')

INSERT INTO [Priority] (priority)
VALUES ('Low'),
	   ('Medium'),
	   ('High')

INSERT INTO Category (category_name)
VALUES ('Work'), ('Personal'), ('Home')

INSERT INTO Tasks (task, status_id, priority_id, due_date, created_at)
VALUES 
    ('Complete report', 1, 3, '2025-04-01', '2025-03-28'),
    ('Buy groceries', 2, 2, '2025-03-30', '2025-03-28'),
    ('Fix the car', 2, 3, '2025-04-05', '2025-03-28'),
    ('Call the bank', 3, 1, '2025-03-25', '2025-03-20'),
    ('Attend team meeting', 2, 2, '2025-04-02', '2025-03-28')

INSERT INTO People (first_name, last_name, age, phone_number)
VALUES 
    ('John', 'Doe', 30, '555-1234'),
    ('Jane', 'Smith', 25, '555-5678'),
    ('Bob', 'Johnson', 40, '555-8765'),
    ('Alice', 'Davis', 35, '555-4321'),
    ('Charlie', 'Brown', 28, '555-7890')

INSERT INTO Task_People (task_id, person_id,time_assigned)
VALUES 
	(2, 1,'2025-03-28'),
    (2, 2,'2025-03-29'),
    (3, 3,'2025-04-01'), 
    (4, 4,'2025-03-21'),
    (5, 5,'2025-03-29')

INSERT INTO Task_Category (task_id, category_id)
VALUES 
    (1, 1), 
    (2, 2),
    (3, 3),
    (4, 2), 
    (5, 1)
	