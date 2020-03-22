import colors from 'vuetify/es5/util/colors'

export default {
  mode: 'universal',
  /*
   ** Headers of the page
   */
  head: {
    titleTemplate: '%s - ' + process.env.npm_package_name,
    title: process.env.npm_package_name || '',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      {
        hid: 'description',
        name: 'description',
        content: process.env.npm_package_description || ''
      }
    ],
    link: [{ rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }]
  },
  /*
   ** Customize the progress-bar color
   */
  loading: { color: '#fff' },
  /*
   ** Global CSS
   */
  css: ['@/assets/sass/main.scss'],
  /*
   ** Plugins to load before mounting the App
   */
  plugins: [],
  /*
   ** Nuxt.js dev-modules
   */
  buildModules: [
    // Doc: https://github.com/nuxt-community/eslint-module
    // '@nuxtjs/eslint-module',
    '@nuxtjs/vuetify'
  ],
  /*
   ** Nuxt.js modules
   */
  modules: [
    // Doc: https://axios.nuxtjs.org/usage
    '@nuxtjs/axios',
    // Doc: https://auth.nuxtjs.org/
    '@nuxtjs/auth'
  ],
  /*
   ** Axios module configuration
   ** See https://axios.nuxtjs.org/options
   */
  axios: {
    baseURL: 'https://localhost:9443'
  },
  /*
   ** Auth module configuration
   ** See https://auth.nuxtjs.org/schemes/oauth2.html#usage
   */
  auth: {
    redirect: {
      login: '/login',
      home: '/',
      callback: '/auth/callback'
    },
    strategies: {
      local: false,
      bezahlstream: {
        _schema: 'local',
        endpoints: {
          login: {
            url: '/oauth/token',
            method: 'post',
            propertyName: 'access_token'
          },
          logout: false,
          user: {
            url: 'api/auth/me',
            method: 'get',
            propertyName: 'user'
          }
        }
      },
      facebook: {
        clientId: process.env.FACEBOOK_CLIENT_ID
      },
      google: {
        clientId: process.env.GOOGLE_CLIENT_ID
      },
      github: {
        clientId: process.env.GITHUB_CLIENT_ID,
        clientSecret: process.env.GITHUB_CLIENT_SECRET
      },
      youtube: {
        clientId: process.env.YOUTUBE_CLIENT_ID
      }
    }
  },
  /*
   ** vuetify module configuration
   ** https://github.com/nuxt-community/vuetify-module
   */
  router: {
    middleware: ['auth']
  },
  vuetify: {
    customVariables: ['~/assets/variables.scss'],
    defaultAssets: {
      font: true,
      icons: 'md'
    },
    icons: {
      iconfont: 'md'
    },
    theme: {
      dark: false,
      themes: {
        dark: {
          primary: colors.blue.darken2,
          accent: colors.grey.darken3,
          secondary: colors.amber.darken3,
          info: colors.teal.lighten1,
          warning: colors.amber.base,
          error: colors.deepOrange.accent4,
          success: colors.green.accent3
        }
      }
    }
  },
  /*
   ** Build configuration
   */
  build: {
    /*
     ** You can extend webpack config here
     */
    extend(config, ctx) {}
  }
}
