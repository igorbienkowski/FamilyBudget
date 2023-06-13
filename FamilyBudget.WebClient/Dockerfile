# Stage 1: Build the Angular app
FROM node:16.15.1-alpine as build

WORKDIR /app

COPY package*.json ./
RUN npm ci --silent
COPY . .
RUN npm run build

# Stage 2: Serve the built Angular app with a lightweight HTTP server
FROM nginx:1.21.0-alpine

COPY --from=build /app/dist/* /usr/share/nginx/html/
COPY ./src/proxy.conf.js /usr/share/nginx/html/

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
