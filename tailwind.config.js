/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: 'class',
  content: [
    './Components/**/*.{razor,html,cshtml}',
    './Pages/**/*.{razor,html,cshtml}',
    './wwwroot/**/*.{html,js}'
  ],
  theme: {
    extend: {
      colors: {
        obsidian: '#0a0c13',
        midnight: '#07080c',
        surface: 'rgba(18, 22, 36, 0.7)',
        surfaceHover: 'rgba(28, 34, 52, 0.8)',
        cyanGlow: '#38bdf8',
        purpleGlow: '#8b5cf6',
        brandViolet: '#7c3aed',
        brandIndigo: '#6366f1',
        brand: {
          dark: '#080B11',
          card: '#0D121D',
          cardInner: '#111726',
          border: '#1E293B',
          purple: '#7C3AED',
          cyan: '#38BDF8',
          emerald: '#34D399',
          amber: '#FB923C'
        }
      },
      fontFamily: {
        sans: ['Inter', '-apple-system', 'BlinkMacSystemFont', 'Segoe UI', 'Roboto', 'sans-serif'],
        mono: ['"JetBrains Mono"', 'Fira Code', 'Courier New', 'monospace'],
      },
      boxShadow: {
        'glow-purple': '0 0 25px -4px rgba(139, 92, 246, 0.35)',
        'glow-cyan': '0 0 20px -4px rgba(56, 189, 248, 0.25)',
        'badge-glow': '0 0 12px -2px rgba(124, 58, 237, 0.25)',
      }
    },
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/container-queries')
  ],
}
