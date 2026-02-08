USE master;
GO

-- Create Coredemo database if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Coredemo')
BEGIN
    CREATE DATABASE Coredemo;
    PRINT 'Coredemo database created successfully.';
    
    -- Set recovery model to SIMPLE for development (optional)
    ALTER DATABASE Coredemo SET RECOVERY SIMPLE;
END
ELSE
BEGIN
    PRINT 'Coredemo database already exists.';
END
GO

USE Coredemo;
GO

-- Verify database is accessible
PRINT 'Connected to Coredemo database successfully.';
GO