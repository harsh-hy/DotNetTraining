using System;
using System.Collections.Generic;
using System.Linq;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Condition { get; set; }
    public List<string> MedicalHistory { get; set; }

    public Patient(int id, string name, int age, string condition)
    {
        Id = id;
        Name = name;
        Age = age;
        Condition = condition;
        MedicalHistory = new List<string>();
    }
}
public class HospitalManager
{
    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
    private Queue<Patient> _appointmentQueue = new Queue<Patient>();

    public void RegisterPatient(int id, string name, int age, string condition)
    {
        if (_patients.ContainsKey(id))
            throw new Exception("Patient already exists");
        Patient p = new Patient(id, name, age, condition);
        _patients.Add(id, p);
    }
    public void ScheduleAppointment(int patientId)
    {
        if (!_patients.ContainsKey(patientId)) 
            throw new Exception("Patient not found");
        _appointmentQueue.Enqueue(_patients[patientId]);
    }
    public Patient ProcessNextAppointment()
    {
        if (_appointmentQueue.Count == 0) 
            return null;
        return _appointmentQueue.Dequeue();
    }
    public List<Patient> FindPatientsByCondition(string condition)
    {
        return _patients.Values
        .Where(p => p.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase))
        .ToList();
    }
}
public class Program
{
    public static void Main()
    {
        HospitalManager manager = new HospitalManager();
        manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
        manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");
        manager.ScheduleAppointment(1);
        manager.ScheduleAppointment(2);
        var nextPatient = manager.ProcessNextAppointment();
        Console.WriteLine(nextPatient.Name);
        var diabeticPatients = manager.FindPatientsByCondition("Diabetes");
        Console.WriteLine(diabeticPatients.Count);
    }
}
