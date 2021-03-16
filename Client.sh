#!/bin/bash
cd veggiestore
npm install --global yarn
yarn install
yarn build
yarn start