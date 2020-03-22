<template>
  <main>
    <v-container fluid fill-height class="loginOverlay">
      <v-layout flex align-center justify-center>
        <v-flex xs12 sm4 elevation-6>
          <v-toolbar class="pt-5 blue darken-4">
            <v-toolbar-title class="white--text">
              <h4>Anmeldung</h4>
            </v-toolbar-title>
          </v-toolbar>
          <v-card>
            <v-card-text class="pt-4">
              <div>
                <v-form ref="form" v-model="valid">
                  <!-- <v-text-field
                    v-model="email"
                    label="E-Mail-Adresse"
                    :rules="emailRules"
                    required
                  ></v-text-field> -->
                  <v-text-field
                    v-model="username"
                    label="Username"
                    :rules="usernameRules"
                    required
                  ></v-text-field>
                  <v-text-field
                    v-model="password"
                    label="Passwort"
                    min="8"
                    :append-icon-cb="() => (e1 = !e1)"
                    :type="e1 ? 'password' : 'text'"
                    :rules="passwordRules"
                    :append-icon="e1 ? 'mdi-eye-off' : 'mdi-eye'"
                    required
                  ></v-text-field>
                  <v-layout justify-space-between>
                    <v-btn
                      :class="{
                        'blue darken-4 white--text': valid,
                        disabled: !valid
                      }"
                      @click="login"
                      >Einloggen</v-btn
                    >
                    <a href="">Passwort vergessen</a>
                  </v-layout>
                </v-form>
              </div>
            </v-card-text>
            <v-divider></v-divider>
            <div class="strategies">
              <div v-for="strategy in strat" :key="strategy.key">
                <v-btn
                  style="color: white"
                  :style="{ background: strategy.color }"
                  class="login-button"
                  @click="$auth.loginWith(strategy.key)"
                >
                  Mit {{ strategy.name }} einloggen
                </v-btn>
              </div>
            </div>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </main>
</template>

<script>
export default {
  name: 'Login',
  data() {
    return {
      valid: false,
      e1: true,
      error: null,
      email: '',
      emailRules: [
        (v) => !!v || 'E-Mail-Adresse wird benötigt',
        (v) =>
          /^\w+([\\.-]?\w+)*@\w+([\\.-]?\w+)*(\.\w{2,3})+$/.test(v) ||
          'Bitte gib eine valide E-Mail-Adresse an'
      ],
      username: '',
      usernameRules: [(v) => !!v || 'Username wird benötigt'],
      password: '',
      passwordRules: [(v) => !!v || 'Passwort wird benötigt']
    }
  },
  computed: {
    strat: () => [
      { key: 'google', name: 'Google', color: '#4284f4', icon: 'google' },
      { key: 'facebook', name: 'Facebook', color: '#3c65c4', icon: 'facebook' },
      { key: 'youtube', name: 'YouTube', color: '#E62117', icon: 'youtube' },
      { key: 'github', name: 'GitHub', color: '#202326', icon: 'github' }
    ]
  },
  methods: {
    async login() {
      try {
        await this.$store.dispatch('auth/login', { data: {
          username: this.username,
          password: this.password
        } })
        this.$router.push('/');
      } catch (err) {
        console.log(err)
      }
    }
  }
}
</script>

<style>
.strategies {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  margin-top: 1rem;
}
.login-button {
  width: 320px;
  text-align: center;
  color: white;
  margin: 0.4rem 0;
}
</style>
