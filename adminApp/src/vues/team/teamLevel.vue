<template>
	<!--信用等级管理-->
	<el-space wrap class="w100" id="search-info">
		<el-space class="search-input">
			<div>团队等级</div>
			<el-input v-model="levelName"></el-input>
		</el-space>
	</el-space>
	<div class="w100 mgt flex-row-between" id="search-button">
		<el-button type="primary" @click="loadData(1)">查询</el-button>
		<el-button type="primary" @click="addItem">添加</el-button>
	</div>
	<el-table v-loading="loading" class="mgt w100" stripe :data="tableData" style="flex: 1" border :height="contentHeight">
		<el-table-column prop="levelName" label="团队等级" width="200" align="center"></el-table-column>
		<el-table-column prop="inviteCount" label="邀请人数" width="200" align="center"></el-table-column>
		<el-table-column prop="teamRepayRate" label="团队还款总金额分红" width="200" align="center"></el-table-column>
		<el-table-column prop="teamBuyRate" label="团队购买理财分润比例" width="200" align="center"></el-table-column>
		<el-table-column prop="levelSort" label="排序" width="100" align="center"></el-table-column>
    <el-table-column prop="" label="操作" align="center" width="200">
			<template #default="scope">
				<el-space> 
					<el-button type="primary" size="small" plain @click="updItem(scope.row)">修改</el-button>
					<el-button type="danger" size="small" plain @click="delItem(scope.row)">删除</el-button>
				</el-space>
			</template>
		</el-table-column>
	</el-table>
	<!--	</div>-->
	<div class="w100 flex-row-end mgt" id="page">
		<el-pagination background layout="prev, pager, next" :total="total" :page-size="pageSize"/>
	</div>


	<el-dialog v-model="windowStatus" v-loading="windowSaving" width="600px">
		<el-space direction="vertical">
			<el-space>
				<div class="in-title">团队等级：</div>
				<el-input class="in-input" v-model="editItem.levelName"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">邀请人数：</div>
				<el-input class="in-input" v-model="editItem.inviteCount"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">团队还款总金额分红：</div>
				<el-input class="in-input" v-model="editItem.teamRepayRate"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">团队购买理财分润比例：</div>
				<el-input class="in-input" v-model="editItem.teamBuyRate"></el-input>
			</el-space> 
			<el-space>
				<div class="in-title">排序：</div>
				<el-input class="in-input" v-model="editItem.levelSort"></el-input>
			</el-space> 

			<el-space>
				<el-button type="primary" @click="saveItem">保存</el-button>
			</el-space>
		</el-space>
	</el-dialog>
</template>

<script> 
	export default {
		name: "teamLevel-manager",
		beforeRouteEnter(to, from, next) {
			next(vm => {
				vm.getTableHeight();
				vm.loadData(1)
			})
		},
		data() {
			return { 
				levelName: '',
				contentHeight: '0px',
				pageIndex: 1,
				pageSize: 20,
				total: 0,
				tableData: [],
				loading: false,
				windowStatus: false,
				editItem: {isEnable:"0",CoverImage:''},
				windowSaving: false, 
			}
		},
	components: {
  
  },
		methods: { 
			delItem(item) {
				const ids=[];
				ids.push(item.id);
				this.$msgbox({
					title: '提示',
					message: '确认删除' + item.levelName + '?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
							this.$Http.post('AdminTeam/TeamLevelDelete', {ids: ids}).then(() => {
								this.loadData();
								done();
							}).catch(res => {
								this.$message.error(res.data.message);
								this.loading = false;
							})
						} else {
							done();
						}
					}
				})

			},
			saveItem() {
				if (!this.editItem.levelName) {
					this.$message.error('请输入团队等级');
					return;
				}
				this.windowSaving = true;
				if (this.editItem.id) {
					this.$Http.post('AdminTeam/TeamLevelUpdate', this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				} else {
					this.$Http.post('AdminTeam/TeamLevelCreate', this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				}

			},
			addItem() {
				this.editItem = {};
				this.windowStatus = true;
				this.windowSaving = false;
        this.editItem.isEnable ='1';
			},
			updItem(item) {
				setTimeout(()=>{
					this.$refs.child.updateUrl(item.CoverImage)
				},10)
			
				this.windowStatus = true;
				this.windowSaving = false;
				this.editItem = JSON.parse(JSON.stringify(item));
        this.editItem.isEnable =''+ item.isEnable+'';
				
			},
			getTime(time) {
				return this.$DateUtil.formatUnix(time / 1000);
			},
			getTableHeight() {
				this.$nextTick(() => {
					let searchInfo = document.getElementById('search-info');
					let searchButton = document.getElementById('search-button');
					let page = document.getElementById('page');

					let height = searchInfo.offsetHeight + searchButton.offsetHeight + page.offsetHeight + 24 + 'px';

					this.contentHeight = 'calc(100% - ' + height + ')'
				})
			},

			loadData(page) {
			
				let param = {};
				if (this.levelName) {
					param.levelName = this.levelName;
				}
				if (page) {
					this.pageIndex = page-1;
				}
				param.pageIndex = this.pageIndex;
				param.pageSize = this.pageSize;
				this.loading = true;
				this.$Http.get('AdminTeam/GetTeamLevelPagedList', {params: param}).then(res => {
				
					this.tableData = res.data.data.items;
					this.total = parseInt(res.data.data.totalCount);
					this.loading = false;
				}).catch((res) => {
					this.$message.error(res.data.data.message);
					this.loading = false;
				})
			}
		}
	}
</script>

<style scoped>
	@import "/src/commcss/flex.css";
	@import "/src/commcss/background.css";

</style>