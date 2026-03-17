USE [StudentPortalDb];
GO
INSERT INTO dbo.Students (FullName, Email, Phone, Status, JoinDate) VALUES
('Arun Kumar', 'arun.kumar@example.com', '9876543210', 'Active', '2026-01-05'),
('Meena R', 'meena.r@example.com', '9876501234', 'Active', '2026-01-07'),
('Karthik S', 'karthik.s@example.com', '9000011111', 'Inactive', '2026-01-10');
INSERT INTO dbo.Courses (Title, DurationDays, Fee, Level, IsActive) VALUES
('ASP.NET Core MVC', 45, 12000.00, 'Beginner', 1),
('Entity Framework Core', 20, 8000.00, 'Intermediate', 1),
('Web API with .NET', 25, 9000.00, 'Intermediate', 1);
INSERT INTO dbo.Enrollments (StudentId, CourseId, EnrollDate, PaymentStatus, PaidAmount) VALUES
(1, 1, '2026-02-01', 'Paid', 12000.00),
(2, 2, '2026-02-03', 'Pending', 2000.00);
GO