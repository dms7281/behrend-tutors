CREATE PROCEDURE InsertClasses
    @Subject NVARCHAR(50),
    @CourseNum INT,
    @SectionNum INT,
    @ClassTitle NVARCHAR(100),
    @ClassCode INT
AS
BEGIN
    DECLARE @SubjectTypeId INT

    SELECT @SubjectTypeId = Id FROM SubjectType WHERE Subject = @Subject

    INSERT INTO Class (SubjectTypeId, CourseNum, SectionNum, ClassTitle, ClassCode) 
    VALUES (@SubjectTypeId, @CourseNum, @SectionNum, @ClassTitle, @ClassCode)
END
