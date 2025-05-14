import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig(({mode}) => {
    const host = mode == 'development' ? 'dnd-dev.aaronic.cc' : 'dnd.aaronic.cc';
    return {
      plugins: [react()],
      server: {
          port: 3000,
          host: true,
          allowedHosts: [
            'web', 
            'localhost', 
            host
          ]
      },
      env: {
        VITE_API_URL: 'http://api:5218'
      }
    }
})
