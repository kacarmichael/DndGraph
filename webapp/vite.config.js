import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
      port: 3000,
      host: true,
      allowedHosts: ['web', 'localhost']
  },
  env: {
    VITE_API_URL: 'http://localhost:5218'
  }
})
