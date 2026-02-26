# Siemens Internship Assignment 2026

This repository contains my practical solutions for the internship selection process at Siemens.

### Problem 1: System Design and Data Modeling
**1. Class Diagram (Business Logic)**
![Class Diagram](./Problem1/class_diagram.png)

* I treated `Beverage` and `Extra` as catalogs. Therefore, the `OrderItem` has a simple directed association to them, rather than a composition or aggregation. An order simply references an item from the menu, it doesn't "own" the definition of a Latte.
* The relationship between `CoffeeShop` and `Barista` is an aggregation. If a physical shop closes, the barista object doesn't need to be destroyed; the employee can be reassigned to a different location.
* For the loyalty points logic, I assumed a straightforward conversion where the `Customer` class handles the balance updates through `addPoints` and `redeemDrink` methods.
