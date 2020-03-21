<template>
  <div>
    <b-navbar type="is-primary">
      <template slot="brand">
        <b-navbar-item tag="router-link" :to="{ path: '/' }">
          stage@home
        </b-navbar-item>
      </template>
    </b-navbar>
    <div class="section">
      <div class="container">
        <nuxt />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {}
  }
}
</script>
