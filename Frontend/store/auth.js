export const state = () => ({
  loggedIn: false,
  strategy: 'bezahlstream',
  user: false
})

export const getters = {
  isAuthenticated(state) {
    return state.auth.loggedIn
  },

  loggedInUser(state) {
    return state.auth.user
  }
}
