-- Table to store students
CREATE TABLE Student (
    Id BIGINT PRIMARY KEY,
    LastName VARCHAR(255) DEFAULT 'User',
    FirstName VARCHAR(255) DEFAULT 'Name'
);