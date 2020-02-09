<template>
  <div id="app" class="container-fluid">
    <div>
      <!-- Image and text -->
      <b-navbar toggleable="lg" variant="faded" type="light">
        <b-navbar-brand tag="h1" class="mb-0" href="/">
          <img
            src="./assets/vinod-logo-30x30.png"
            class="d-inline-block align-top"
            alt="Vinod-Logo"
          />
          Vinod's Blog
        </b-navbar-brand>
        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <b-collapse id="nav-collapse" is-nav>
          <!-- Right aligned nav items -->
          <b-navbar-nav class="ml-auto" v-if="!$auth.loading">
            <b-nav-item v-if="$auth.isAuthenticated" href="/create">Create Blog</b-nav-item>
            <b-nav-item v-if="$auth.isAuthenticated" href="/admin">Edit Blogs</b-nav-item>
            <!-- show logout and username when authenticated -->
            <b-nav-item-dropdown v-if="$auth.isAuthenticated" right>
              <!-- Using 'button-content' slot -->
              <template v-slot:button-content>
                <em>{{ $auth.user.name }}</em>
              </template>
              <b-dropdown-item href="#" @click="logout">Sign Out</b-dropdown-item>
            </b-nav-item-dropdown>
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </div>
    <div class="row">
      <div class="col-xl-3 col-lg-2 col-md-1 col-sm-1"></div>
      <div class="col-xl-6 col-lg-8 col-md-10 col-sm-10 col-xs-12">
        <transition>
          <keep-alive>
            <router-view :key="$route.fullPath"></router-view>
          </keep-alive>
        </transition>
      </div>
      <div class="col-xl-3 col-lg-2 col-md-1 col-sm-1"></div>
    </div>
  </div>
</template>
<script>
export default {
  name: "app",
  methods: {
    // Log the user out
    logout() {
      this.$auth.logout({
        returnTo: window.location.origin
      });
    }
  }
};
</script>
<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: left;
  font-size: 100%;
  color: #222222;
  text-rendering: optimizeLegibility;
  line-height: 1.625;
}
.navbar-brand {
  font-weight: 500;
}
</style>
