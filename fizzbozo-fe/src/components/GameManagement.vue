<script>
export default {
  name: 'GameManagement',
}
</script>

<template>
    <div class = "container home-container">
        <div>
            <h1 class="text-center mt-5">Game Management</h1>
            <hr></hr>

            <div class = "row mt-4">
                <div class="col-md-4">
                    <div class="card fizzbozo-card" @click="handleClick">
                        <div class="card-body d-flex align-items-center justify-content-center">
                            <svg xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="currentColor" class="bi bi-plus" viewBox="0 0 16 16">
                                <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4"/>
                            </svg>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card fizzbozo-card fizzbozo-card-content" style = "background-color: #fffefe;" @click="handleClick" >
                        <div class="card-body text-center">
                            <h4 class="card-title  mt-2 mb-4">STUPID GAME 1</h4>
                            <h5 class="card-text">Created by</h5>
                            <p>Peter</p>
                            <h5 class="card-text">Number of Rules</h5>
                            <p>4</p>
                            <h5 class="card-text">Number Range</h5>
                            <p>23-136</p>
                            <div class = "d-flex justify-content-between align-items-center">
                                <button class="btn btn-card" 
                                style="border-right: 1px solid #e0e0e0;
                                border-radius: 10px 0px 0px 10px; ">
                                    Play
                                </button>
                                <button class="btn btn-card" 
                                style="border-left: 1px solid #e0e0e0;
                                border-radius: 0px 10px 10px 0px;
                                color: red">
                                    Delete
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card fizzbozo-card fizzbozo-card-content" style = "background-color: #fffefe;" @click="handleClick" >
                        <div class="card-body text-center">
                            <h4 class="card-title  mt-2 mb-4">STUPID GAME 1</h4>
                            <h5 class="card-text">Created by</h5>
                            <p>Peter</p>
                            <h5 class="card-text">Number of Rules</h5>
                            <p>4</p>
                            <h5 class="card-text">Number Range</h5>
                            <p>23-136</p>
                            <div class = "d-flex justify-content-between align-items-center">
                                <button class="btn btn-card" 
                                style="border-right: 1px solid #e0e0e0;
                                border-radius: 10px 0px 0px 10px; ">
                                    Play
                                </button>
                                <button class="btn btn-card" 
                                style="border-left: 1px solid #e0e0e0;
                                border-radius: 0px 10px 10px 0px;
                                color: red">
                                    Delete
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>

    </div>
</template>

<style scoped>
.fizzbozo-card {
  width: 250px; /* Adjust width as needed */
  height: 350px; /* Adjust height as needed */
  background-color: #f1f1f1; /* Light grey color */
  border: 1px solid #e0e0e0; /* Optional: subtle border */
  border-radius: 10px;
  cursor: pointer;
  box-shadow: 0 4px 6px rgba(0,0,0,0.1);
  transition: transform 0.2s, box-shadow 0.2s;
}

.fizzbozo-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 6px 12px rgba(0,0,0,0.15);
}

.fizzbozo-card .card-body {
  height: 100%;
}

.fizzbozo-card svg {
  color: #999; /* Grey color for the plus icon */
}

.fizzbozo-card-content{
    font-size: 1.1rem;
    font-weight: 400;
    color: #5C5C5C;
}

.fizzbozo-card-content h4, h5{
    color: #5A7FB7;

}

.btn-card {
    width: 100%;
    color: #5A7FB7;
    font-size: 1.2rem;
    font-weight: 500;

}
</style>