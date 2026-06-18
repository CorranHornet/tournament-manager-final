# Tournament Manager System

![Build Status](https://github.com/CorranHornet/tournament-manager-final/actions/workflows/ci.yml/badge.svg)

A fullstack tournament management system designed with a focus on modern architecture, testability, and scalability. This project demonstrates high-quality code standards by implementing Clean Architecture and robust design patterns.

## 📜 Project History & Migration
This repository represents the final, consolidated version of the Tournament Manager application. To maintain transparency regarding the development process, CI/CD pipeline, and architectural decisions, the full development history is preserved in the original repository.

* Original Development Repository: [CorranHornet/tournament-manager-fullstack](https://github.com/CorranHornet/tournament-manager-fullstack)
* Development Workflow: Please refer to the [original repository's Pull Requests](https://github.com/CorranHornet/tournament-manager-fullstack/pulls) to review implementation details, architectural decisions, and code reviews.
* CI/CD Verification: The continuous integration history can be verified in the [original repository's Actions tab](https://github.com/CorranHornet/tournament-manager-fullstack/actions).

## 🛠 Tech Stack

### Backend
* Framework: .NET 8 (ASP.NET Core Web API)
* Architecture: Clean Architecture
* Data Access: Entity Framework Core
* Design Patterns: Generic Repository Pattern, Dependency Injection

### Frontend
* Framework: React (Vite)
* Language: TypeScript/JavaScript

## 🚀 Key Features
* Generic Repository: Implemented for centralized and reusable data access logic.
* Clean Architecture: Ensures decoupling of business logic from infrastructure concerns.
* Fullstack Integration: Seamless communication between the React frontend and the backend API.
* Automated Pipeline: Every push is automatically verified via GitHub Actions to ensure code integrity.

## 💻 Getting Started

### Prerequisites
* .NET SDK 8.0+
* Node.js (Latest LTS recommended)

### Installation
1. Clone the repository:
git clone https://github.com/CorranHornet/tournament-manager-final.git

2. Backend Setup:
cd tournament-manager
dotnet restore
dotnet run

3. Frontend Setup:
cd tournament-frontend
npm install
npm run dev
