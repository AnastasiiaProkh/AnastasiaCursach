"use client";
import React from "react";
import { Container, Button, Card } from "reactstrap";
import "./page.css";

export default function Home() {
  return (
    <div className="App">
      <Card className="hero-section">
        <Container>
          <h1>Welcome to Cursova!</h1>
          <p>
            This project aims to teach you about database normalization and
            building a basic CRUD app using .NET 7, MS SQL, and React.js.
          </p>
        </Container>
      </Card>

      <Container className="main-content">
        <h2>Database Normalization and CRUD app</h2>
        <p>
          In this project, you will learn how to normalize a database and create
          a basic CRUD app using .NET 7, MS SQL, and React.js. This app will
          allow you to create, read, update, and delete records from the
          database, and demonstrate the power and efficiency of a normalized
          database structure.
        </p>
      </Container>
    </div>
  );
}
