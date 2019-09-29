<template>
  <div id="app" class="container-fluid">
    <div class="row">
      <div class="col-xl-3 col-lg-2 col-md-1 col-sm-1"></div>
      <div class="col-xl-6 col-lg-8 col-md-10 col-sm-10 col-xs-12">
        <router-view />
      </div>
      <div class="col-xl-3 col-lg-2 col-md-1 col-sm-1"></div>
    </div>
  </div>
</template>

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
</style>
