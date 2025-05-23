-- Table to store students
CREATE TABLE CATALOGUE (
    Subject_Id BIGINT NOT NULL ,
    Student_Id BIGINT NOT NULL,
    Grade DECIMAL(18, 2) NULL,
    Nb_Absences DECIMAL(18, 2) NULL,
    Nb_Attendances DECIMAL(18, 2) NULL,
	PRIMARY KEY (SubjectId, StudentId)
);               