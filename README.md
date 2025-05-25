# 💊 PrescriptionAPI

A simple ASP.NET Core Web API for managing medical prescriptions, patients, doctors, and medications using the Entity Framework Core Code-First approach.

## 🚀 Features

- Add a new prescription with patient and medication details
- Automatically create a patient if not already in the database
- Validates medication existence and limits to a maximum of 10 per prescription
- Ensures `DueDate >= Date` on prescriptions
- Retrieve all patient information including:
  - Prescriptions
  - Doctors
  - Medications with dose and details
- Follows REST principles and layered architecture (DTOs, services, controllers)
- Unit-test ready

---

## 📦 Tech Stack

- ASP.NET Core 7 / 8
- Entity Framework Core (Code-First)
- SQL Server
- Swagger / OpenAPI (for testing endpoints)

---

## ⚙️ Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/sher304/PrescriptionAPI.git
cd PrescriptionAPI
