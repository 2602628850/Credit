<template>
	<!--信用等级管理-->
	<el-space wrap class="w100" id="search-info">
		<el-space class="search-input">
			<div>产品名称</div>
			<el-input v-model="productName"></el-input>
		</el-space>
	</el-space>
	<div class="w100 mgt flex-row-between" id="search-button">
		<el-button type="primary" @click="loadData(1)">查询</el-button>
		<el-button type="primary" @click="addItem">添加</el-button>
	</div>
	<el-table v-loading="loading" class="mgt w100" stripe :data="tableData" style="flex: 1" border :height="contentHeight">
		<el-table-column prop="productName" label="产品名称" width="150" align="center"></el-table-column>
		
		<el-table-column prop="dailyRate" label="日收益比例（%）" width="120" align="center"></el-table-column>
		<el-table-column prop="cycle" label="收益周期（天）" width="120" align="center"></el-table-column>
		<el-table-column prop="price" label="价格" width="100" align="center"></el-table-column>
		<el-table-column prop="buyMinUnit" label="最低购买数" width="100" align="center"></el-table-column>
		<el-table-column prop="buyMaxUnit" label="最大购买数" width="100" align="center"></el-table-column>
		<el-table-column prop="isEnable" label="是否启用" width="100" align="center">
			<template #default="scope">
				{{ scope.row.isEnable=="1"?"上架":"下架"}}
			</template>
		</el-table-column>
    <el-table-column prop="" label="操作" align="center" width="200">
			<template #default="scope">
				<el-space>
					<el-button type="danger" size="small" plain @click="upXJ(scope.row)" v-if="scope.row.isEnable==1">下架</el-button>
					<el-button type="primary" size="small" plain @click="upQY(scope.row)" v-else>上架</el-button>
					<el-button type="primary" size="small" plain @click="updItem(scope.row)">修改</el-button>
				
					<el-button type="danger" v-show="isChooseDel==0" size="small" plain @click="delItem(scope.row,1)">删除</el-button>
					<el-button type="danger" v-show="isChooseDel==1"  size="small" plain @click="delItem(scope.row,0)">删除</el-button>
				</el-space>
			</template>
		</el-table-column>
	</el-table>
	<!--	</div>-->
	<div class="w100 flex-row-end mgt" id="page">
		<el-pagination background layout="prev, pager, next" @current-change="currentPage" :total="total" :page-size="pageSize"/>
	</div>


	<el-dialog v-model="windowStatus" v-loading="windowSaving" width="600px">
		<el-space direction="vertical">
			<el-space>
				<div class="in-title">产品名称：</div>
				<el-input class="in-input" v-model="editItem.productName"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">日收益比例（%）：</div>
				<el-input class="in-input" v-model="editItem.dailyRate"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">收益周期（天）：</div>
				<el-input class="in-input" v-model="editItem.cycle"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">单价：</div>
				<el-input class="in-input" v-model="editItem.price"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">最低购买数：</div>
				<el-input class="in-input" v-model="editItem.buyMinUnit"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">最高购买数：</div>
				<el-input class="in-input" v-model="editItem.buyMaxUnit"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">排序：</div>
				<el-input class="in-input" v-model="editItem.sort"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">是否启用：</div>
			<el-radio-group v-model="editItem.isEnable"  class="in-input">
        <el-radio label="1" >启用</el-radio>
        <el-radio label="0" >禁用</el-radio>
      </el-radio-group>
			</el-space>
				<el-space>
						<div class="in-title" style="margin-left:-60px;" >产品封面</div>
              <upload-picture  v-model:logourl="coverImage" ref="child">

							</upload-picture>
				</el-space>
			<el-space>
				<div class="in-title">产品简介：</div>
				<el-input  :rows="3"  type="textarea" class="in-input" v-model="editItem.introduction"></el-input>
			</el-space> 


			<el-space>
				<el-button type="primary" @click="saveItem">保存</el-button>
			</el-space>
		</el-space>
	</el-dialog>
</template>

<script>
import uploadFile  from "../../components/uploadPicture.vue"
	export default {
		name: "product-manager",
		beforeRouteEnter(to, from, next) {
			next(vm => {
				vm.getTableHeight();
				vm.loadData(1)
			})
		},
		data() {
			return {
					isChooseDel:0,
			uploadUrl: 'http://localhost:8003/v1/Upload/Image',
				productName: '',
				contentHeight: '0px',
				pageIndex: 1,
				pageSize: 20,
				total: 0,
				tableData: [],
				loading: false,
				windowStatus: false,
				editItem: {isEnable:"0",coverImage:''},
				windowSaving: false,
				coverImage:'',
			}
		},
	components: {
  "upload-picture":uploadFile
  },
		methods: {
				currentPage(pageindex){
          this.loadData(pageindex)
				},
			// 上传前，限制的上传图片大小
			beforeImageUpload(rawFile){
                if(rawFile.size / 1024 / 1024 > 10){
                    this.$message.error("单张图片大小不能超过10MB!");
                    return false;
                }
                return true;
            },
						// 上传成功，获取返回的图片地址
            handleUpImage(res){
                this.editItem.coverImage = res.data.url;
            },
			delItem(item,indexcho) {
				const ids=[];
				ids.push(item.id);
				this.$msgbox({
					title: '提示',
					message: '确认删除' + item.productName + '?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
							this.$Http.post('AdminProduct/FinancialProductDelete', {ids: ids}).then(() => {
								this.loadData();
								done();
							this.isChooseDel=indexcho;
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
			upQY(item) {
				const ids=[];
				ids.push(item.id);
				this.$msgbox({
					title: '提示',
					message: '确认上架' + item.productName + '?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
							this.$Http.post('AdminProduct/FinancialProductTakeOn', {ids: ids}).then(() => {
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
			upXJ(item) {
				const ids=[];
				ids.push(item.id);
				this.$msgbox({
					title: '提示',
					message: '确认下架' + item.productName + '?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
							this.$Http.post('AdminProduct/FinancialProductTakeDown', {ids: ids}).then(() => {
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
				if (!this.editItem.productName) {
					this.$message.error('请输入产品名称');
					return;
				}
				if (this.$ObjectUtil.isEmpty(this.editItem.isEnable)) {
					this.$message.error('请选择是否启用');
					return;
				}
				this.windowSaving = true;
				this.editItem.coverImage=this.coverImage;//图片路径
				if (this.editItem.id) {
					this.$Http.post('AdminProduct/FinanacialProductUpdate', this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				} else {
					this.$Http.post('AdminProduct/FinanacialProductCreate', this.editItem).then(() => {
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
					this.$refs.child.updateUrl(item.coverImage)
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
				if (this.productName) {
					param.productName = this.productName;
				}
				if (page) {
					this.pageIndex = page-1;
				}
				param.pageIndex = this.pageIndex;
				param.pageSize = this.pageSize;
				this.loading = true;
				this.$Http.get('AdminProduct/GetProductPagedList', {params: param}).then(res => {
				
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