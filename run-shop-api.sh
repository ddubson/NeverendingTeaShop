#!/usr/bin/env bash

# Go to base directory
pushd $(git rev-parse --show-toplevel)

# Run the API project
dotnet run --project src/NeverendingTeaShop.API
