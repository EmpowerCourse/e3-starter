import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import mkcert from "vite-plugin-mkcert";

export default defineConfig({
    plugins: [react(), mkcert()],
    server: {
        https: true,
        port: 3000,
        strictPort: true,
        proxy: {
            "/api": { target: "https://localhost:5000", secure: false },
        },
    },
});
