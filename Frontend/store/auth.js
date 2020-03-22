const qs = require('querystring')

export const state = () => ({
  token: '',
  tokenType: '',
  clientId: 'client',
  grantType: 'password',
  scopes: 'api1 offline_access'
})

export const mutations = {
  setToken(state, {access_token, token_type}){
    state.token = access_token;
    state.tokenType = token_type;
  }
}

export const actions = {
  async login({ state, commit }, { data }) {
    try {
      commit('setToken', await this.$axios.$post('/connect/token', qs.stringify({
        ...data,
        client_id: state.clientId,
        grant_type: state.grantType,
        scope: state.scopes
      }),
        {
          headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
          }
        }));
    } catch (ex) {
      console.log(ex)
    }
  }
}